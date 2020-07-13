namespace GSP.Template.Wizard.Forms
{
    partial class CommonTemplateProjectSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._domainNameLabel = new System.Windows.Forms.Label();
            this._plainProjectNameLabel = new System.Windows.Forms.Label();
            this._domainName = new System.Windows.Forms.TextBox();
            this._plainProjectName = new System.Windows.Forms.TextBox();
            this._createButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _domainNameLabel
            // 
            this._domainNameLabel.AutoSize = true;
            this._domainNameLabel.Location = new System.Drawing.Point(13, 23);
            this._domainNameLabel.Name = "_domainNameLabel";
            this._domainNameLabel.Size = new System.Drawing.Size(110, 17);
            this._domainNameLabel.TabIndex = 0;
            this._domainNameLabel.Text = "* Domain Name:";
            // 
            // _plainProjectNameLabel
            // 
            this._plainProjectNameLabel.AutoSize = true;
            this._plainProjectNameLabel.Location = new System.Drawing.Point(16, 90);
            this._plainProjectNameLabel.Name = "_plainProjectNameLabel";
            this._plainProjectNameLabel.Size = new System.Drawing.Size(141, 17);
            this._plainProjectNameLabel.TabIndex = 1;
            this._plainProjectNameLabel.Text = "* Plain Project Name:";
            // 
            // _domainName
            // 
            this._domainName.Location = new System.Drawing.Point(19, 44);
            this._domainName.Name = "_domainName";
            this._domainName.Size = new System.Drawing.Size(189, 22);
            this._domainName.TabIndex = 2;
            // 
            // _plainProjectName
            // 
            this._plainProjectName.Location = new System.Drawing.Point(19, 111);
            this._plainProjectName.Name = "_plainProjectName";
            this._plainProjectName.Size = new System.Drawing.Size(189, 22);
            this._plainProjectName.TabIndex = 3;
            // 
            // _createButton
            // 
            this._createButton.Location = new System.Drawing.Point(19, 146);
            this._createButton.Name = "_createButton";
            this._createButton.Size = new System.Drawing.Size(107, 31);
            this._createButton.TabIndex = 4;
            this._createButton.Text = "Create";
            this._createButton.UseVisualStyleBackColor = true;
            this._createButton.Click += new System.EventHandler(this.CreateButtonClickHandler);
            // 
            // CommonTemplateProjectSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 201);
            this.ControlBox = false;
            this.Controls.Add(this._createButton);
            this.Controls.Add(this._plainProjectName);
            this.Controls.Add(this._domainName);
            this.Controls.Add(this._plainProjectNameLabel);
            this.Controls.Add(this._domainNameLabel);
            this.Name = "CommonTemplateProjectSettingForm";
            this.Text = "GSP Project Template Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _domainNameLabel;
        private System.Windows.Forms.Label _plainProjectNameLabel;
        private System.Windows.Forms.TextBox _domainName;
        private System.Windows.Forms.TextBox _plainProjectName;
        private System.Windows.Forms.Button _createButton;
    }
}