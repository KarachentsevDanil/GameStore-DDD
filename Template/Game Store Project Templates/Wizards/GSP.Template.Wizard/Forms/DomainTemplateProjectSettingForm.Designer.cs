namespace GSP.Template.Wizard.Forms
{
    partial class DomainTemplateProjectSettingForm
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
            this._domainName = new System.Windows.Forms.TextBox();
            this._createButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _domainNameLabel
            // 
            this._domainNameLabel.AutoSize = true;
            this._domainNameLabel.Location = new System.Drawing.Point(34, 26);
            this._domainNameLabel.Name = "_domainNameLabel";
            this._domainNameLabel.Size = new System.Drawing.Size(110, 17);
            this._domainNameLabel.TabIndex = 0;
            this._domainNameLabel.Text = "* Domain Name:";
            // 
            // _domainName
            // 
            this._domainName.Location = new System.Drawing.Point(37, 47);
            this._domainName.Multiline = true;
            this._domainName.Name = "_domainName";
            this._domainName.Size = new System.Drawing.Size(189, 22);
            this._domainName.TabIndex = 1;
            // 
            // _createButton
            // 
            this._createButton.Location = new System.Drawing.Point(37, 91);
            this._createButton.Name = "_createButton";
            this._createButton.Size = new System.Drawing.Size(107, 31);
            this._createButton.TabIndex = 2;
            this._createButton.Text = "Create";
            this._createButton.UseVisualStyleBackColor = true;
            this._createButton.Click += new System.EventHandler(this.CreateButtonClickHandler);
            // 
            // DomainTemplateProjectSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 181);
            this.ControlBox = false;
            this.Controls.Add(this._createButton);
            this.Controls.Add(this._domainName);
            this.Controls.Add(this._domainNameLabel);
            this.Name = "DomainTemplateProjectSettingForm";
            this.Text = "GSP Project Template Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _domainNameLabel;
        private System.Windows.Forms.TextBox _domainName;
        private System.Windows.Forms.Button _createButton;
    }
}