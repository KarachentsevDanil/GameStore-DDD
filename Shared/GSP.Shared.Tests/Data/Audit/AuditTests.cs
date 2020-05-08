using AutoFixture;
using FakeItEasy;
using GSP.Shared.Tests.Fakes.Context;
using GSP.Shared.Tests.Fakes.Entities;
using GSP.Shared.Utils.Common.Date.Contracts;
using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.Common.Sessions.Models;
using GSP.Shared.Utils.Data.Context.Audit;
using GSP.Shared.Utils.Data.Context.Audit.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GSP.Shared.Tests.Data.Audit
{
    public class AuditTests : IDisposable
    {
        private readonly FakeDbContext _context;

        private readonly IFixture _fixture;

        private readonly IDateTimeService _dateTimeService;

        private readonly IAuditService _auditService;

        private readonly IGspSession _gspSession;

        private readonly GspUserAccountModel _accountModel;

        public AuditTests()
        {
            DbContextOptions<FakeDbContext> mockOptions = new DbContextOptionsBuilder<FakeDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _gspSession = A.Fake<IGspSession>();

            _dateTimeService = A.Fake<IDateTimeService>();

            _auditService = new AuditService(A.Fake<ILogger<AuditService>>(), _dateTimeService, _gspSession);

            _context = new FakeDbContext(mockOptions, _gspSession, _auditService);

            _fixture = new Fixture();

            _accountModel = _fixture.Create<GspUserAccountModel>();
        }

        [Fact]
        public async Task CreateAuditableEntity_SessionIsNotNull_AuditableInfoShouldBeSet()
        {
            // Arrange
            var auditableEntity = _fixture.Create<FakeAuditableEntity>();

            A.CallTo(() => _gspSession.GetUserAccountOrDefault())
                .Returns(_accountModel);

            var currentTime = _fixture.Create<DateTime>();

            A.CallTo(() => _dateTimeService.UtcNow)
                .Returns(currentTime);

            // Act
            _context.FakeAuditableEntities.Add(auditableEntity);
            await _context.SaveChangesAsync();

            // Asset
            A.CallTo(() => _gspSession.GetUserAccountOrDefault())
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _dateTimeService.UtcNow)
                .MustHaveHappenedOnceExactly();

            var savedAuditableEntity = await _context.FakeAuditableEntities.FindAsync(auditableEntity.Id);

            Assert.Equal(savedAuditableEntity.CreatedByAccountId, _accountModel.Id);
            Assert.Equal(savedAuditableEntity.UpdatedByAccountId, _accountModel.Id);

            Assert.Equal(savedAuditableEntity.CreatedAt, currentTime);
            Assert.Equal(savedAuditableEntity.UpdatedAt, currentTime);
        }

        [Fact]
        public async Task UpdateAuditableEntity_SessionIsNotNull_AuditableInfoShouldBeSet()
        {
            // Arrange
            var auditableEntity = _fixture.Create<FakeAuditableEntity>();

            A.CallTo(() => _gspSession.GetUserAccountOrDefault())
                .Returns(_accountModel);

            var currentTime = _fixture.Create<DateTime>();

            A.CallTo(() => _dateTimeService.UtcNow)
                .Returns(currentTime);

            _context.FakeAuditableEntities.Add(auditableEntity);
            await _context.SaveChangesAsync();

            var newTime = _fixture.Create<DateTime>();

            A.CallTo(() => _dateTimeService.UtcNow)
                .Returns(newTime);

            var newUserInfo = _fixture.Create<GspUserAccountModel>();

            A.CallTo(() => _gspSession.GetUserAccountOrDefault())
                .Returns(newUserInfo);

            // Act
            auditableEntity.Update(_fixture.Create<string>(), _fixture.Create<string>());
            _context.FakeAuditableEntities.Update(auditableEntity);
            await _context.SaveChangesAsync();

            // Asset
            A.CallTo(() => _gspSession.GetUserAccountOrDefault())
                .MustHaveHappenedTwiceExactly();

            A.CallTo(() => _dateTimeService.UtcNow)
                .MustHaveHappenedTwiceExactly();

            var savedAuditableEntity = await _context.FakeAuditableEntities.FindAsync(auditableEntity.Id);

            Assert.Equal(savedAuditableEntity.CreatedByAccountId, _accountModel.Id);
            Assert.Equal(savedAuditableEntity.UpdatedByAccountId, newUserInfo.Id);

            Assert.Equal(savedAuditableEntity.CreatedAt, currentTime);
            Assert.Equal(savedAuditableEntity.UpdatedAt, newTime);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }
        }
    }
}