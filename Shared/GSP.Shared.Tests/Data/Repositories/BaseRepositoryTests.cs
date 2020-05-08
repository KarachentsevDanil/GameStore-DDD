using AutoFixture;
using DeepEqual.Syntax;
using FakeItEasy;
using GSP.Shared.Tests.Fakes.Context;
using GSP.Shared.Tests.Fakes.Entities;
using GSP.Shared.Utils.Common.Sessions.Contracts;
using GSP.Shared.Utils.Data.Context.Audit.Contracts;
using GSP.Shared.Utils.Data.Repositories;
using GSP.Shared.Utils.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GSP.Shared.Tests.Data.Repositories
{
    public class BaseRepositoryTests : IDisposable
    {
        private readonly FakeDbContext _context;

        private readonly IFixture _fixture;

        private readonly IAuditService _auditService;

        private readonly IGspSession _gspSession;

        public BaseRepositoryTests()
        {
            DbContextOptions<FakeDbContext> mockOptions = new DbContextOptionsBuilder<FakeDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _auditService = A.Fake<IAuditService>();

            _gspSession = A.Fake<IGspSession>();

            _context = new FakeDbContext(mockOptions, _gspSession, _auditService);

            _fixture = new Fixture();
        }

        [Fact]
        public async Task Create_ValidEntity_ShouldCreateBeCreated()
        {
            // Arrange
            string name = _fixture.Create<string>();
            string description = _fixture.Create<string>();

            FakeEntity entity = new FakeEntity(name, description);
            IBaseRepository<FakeEntity> repository = new BaseRepository<FakeDbContext, FakeEntity>(_context);

            // Act
            repository.Create(entity);
            await _context.SaveChangesAsync();

            // Assert
            FakeEntity actualResult = await _context.FakeEntities.FindAsync(entity.Id);

            Assert.NotNull(actualResult);

            entity
                .WithDeepEqual(actualResult)
                .Assert();
        }

        [Fact]
        public async Task Update_ValidEntity_ShouldCreateBeUpdated()
        {
            // Arrange
            FakeEntity entity = new FakeEntity(_fixture.Create<string>(), _fixture.Create<string>());

            IBaseRepository<FakeEntity> repository = new BaseRepository<FakeDbContext, FakeEntity>(_context);
            _context.FakeEntities.Add(entity);
            await _context.SaveChangesAsync();

            entity.Update(_fixture.Create<string>(), _fixture.Create<string>());

            // Act
            repository.Update(entity);
            await _context.SaveChangesAsync();

            // Assert
            FakeEntity actualResult = await _context.FakeEntities.FindAsync(entity.Id);

            Assert.NotNull(actualResult);

            entity
                .WithDeepEqual(actualResult)
                .Assert();
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