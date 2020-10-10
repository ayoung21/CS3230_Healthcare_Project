namespace Healthcare_System.View
{
    partial class Wrapper
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
            this.appComponents = new System.Windows.Forms.TabControl();
            this.People = new System.Windows.Forms.TabPage();
            this.loggedInUser = new System.Windows.Forms.Label();
            this.logOut = new System.Windows.Forms.Button();
            this.appComponents.SuspendLayout();
            this.SuspendLayout();
            // 
            // appComponents
            // 
            this.appComponents.Controls.Add(this.People);
            this.appComponents.Location = new System.Drawing.Point(12, 41);
            this.appComponents.Name = "appComponents";
            this.appComponents.SelectedIndex = 0;
            this.appComponents.Size = new System.Drawing.Size(1271, 656);
            this.appComponents.TabIndex = 0;
            // 
            // People
            // 
            this.People.Location = new System.Drawing.Point(4, 22);
            this.People.Name = "People";
            this.People.Padding = new System.Windows.Forms.Padding(3);
            this.People.Size = new System.Drawing.Size(1263, 630);
            this.People.TabIndex = 0;
            this.People.Text = "People";
            this.People.UseVisualStyleBackColor = true;
            // 
            // loggedInUser
            // 
            this.loggedInUser.AutoSize = true;
            this.loggedInUser.Location = new System.Drawing.Point(1201, 9);
            this.loggedInUser.Name = "loggedInUser";
            this.loggedInUser.Size = new System.Drawing.Size(82, 13);
            this.loggedInUser.TabIndex = 0;
            this.loggedInUser.Text = "Hello, PERSON";
            this.loggedInUser.Click += new System.EventHandler(this.label1_Click);
            // 
            // logOut
            // 
            this.logOut.Location = new System.Drawing.Point(1208, 25);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(75, 23);
            this.logOut.TabIndex = 1;
            this.logOut.Text = "Log Out";
            this.logOut.UseVisualStyleBackColor = true;
            // 
            // Wrapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 709);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.loggedInUser);
            this.Controls.Add(this.appComponents);
            this.Name = "Wrapper";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.appComponents.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl appComponents;
        private System.Windows.Forms.TabPage People;
        private System.Windows.Forms.Label loggedInUser;
        private System.Windows.Forms.Button logOut;
    }
}