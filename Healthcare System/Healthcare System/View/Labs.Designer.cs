namespace Healthcare_System.View
{
    partial class Labs
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
            this.listViewTests = new System.Windows.Forms.ListView();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.buttonCancelEditResults = new System.Windows.Forms.Button();
            this.buttonSaveResults = new System.Windows.Forms.Button();
            this.checkBoxAbnormal = new System.Windows.Forms.CheckBox();
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.buttonEditResults = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTestOrder = new System.Windows.Forms.ComboBox();
            this.buttonAddTestToOrder = new System.Windows.Forms.Button();
            this.buttonSubmitOrder = new System.Windows.Forms.Button();
            this.dateTimePickerTest = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRemoveTest = new System.Windows.Forms.Button();
            this.groupBoxResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewTests
            // 
            this.listViewTests.HideSelection = false;
            this.listViewTests.Location = new System.Drawing.Point(8, 51);
            this.listViewTests.Margin = new System.Windows.Forms.Padding(2);
            this.listViewTests.Name = "listViewTests";
            this.listViewTests.Size = new System.Drawing.Size(584, 319);
            this.listViewTests.TabIndex = 0;
            this.listViewTests.UseCompatibleStateImageBehavior = false;
            this.listViewTests.View = System.Windows.Forms.View.Details;
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.Controls.Add(this.label2);
            this.groupBoxResults.Controls.Add(this.dateTimePickerTest);
            this.groupBoxResults.Controls.Add(this.buttonCancelEditResults);
            this.groupBoxResults.Controls.Add(this.buttonSaveResults);
            this.groupBoxResults.Controls.Add(this.checkBoxAbnormal);
            this.groupBoxResults.Controls.Add(this.textBoxResults);
            this.groupBoxResults.Enabled = false;
            this.groupBoxResults.Location = new System.Drawing.Point(8, 402);
            this.groupBoxResults.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxResults.Size = new System.Drawing.Size(584, 244);
            this.groupBoxResults.TabIndex = 1;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Results";
            // 
            // buttonCancelEditResults
            // 
            this.buttonCancelEditResults.Location = new System.Drawing.Point(456, 215);
            this.buttonCancelEditResults.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancelEditResults.Name = "buttonCancelEditResults";
            this.buttonCancelEditResults.Size = new System.Drawing.Size(56, 19);
            this.buttonCancelEditResults.TabIndex = 3;
            this.buttonCancelEditResults.Text = "Cancel";
            this.buttonCancelEditResults.UseVisualStyleBackColor = true;
            // 
            // buttonSaveResults
            // 
            this.buttonSaveResults.Location = new System.Drawing.Point(523, 215);
            this.buttonSaveResults.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveResults.Name = "buttonSaveResults";
            this.buttonSaveResults.Size = new System.Drawing.Size(56, 19);
            this.buttonSaveResults.TabIndex = 2;
            this.buttonSaveResults.Text = "Save";
            this.buttonSaveResults.UseVisualStyleBackColor = true;
            // 
            // checkBoxAbnormal
            // 
            this.checkBoxAbnormal.Location = new System.Drawing.Point(4, 215);
            this.checkBoxAbnormal.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxAbnormal.Name = "checkBoxAbnormal";
            this.checkBoxAbnormal.Size = new System.Drawing.Size(87, 17);
            this.checkBoxAbnormal.TabIndex = 1;
            this.checkBoxAbnormal.Text = "Is abnormal";
            this.checkBoxAbnormal.UseVisualStyleBackColor = true;
            // 
            // textBoxResults
            // 
            this.textBoxResults.Location = new System.Drawing.Point(4, 17);
            this.textBoxResults.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxResults.MaxLength = 200;
            this.textBoxResults.Multiline = true;
            this.textBoxResults.Name = "textBoxResults";
            this.textBoxResults.Size = new System.Drawing.Size(576, 187);
            this.textBoxResults.TabIndex = 0;
            // 
            // buttonEditResults
            // 
            this.buttonEditResults.Location = new System.Drawing.Point(511, 374);
            this.buttonEditResults.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEditResults.Name = "buttonEditResults";
            this.buttonEditResults.Size = new System.Drawing.Size(80, 23);
            this.buttonEditResults.TabIndex = 2;
            this.buttonEditResults.Text = "Edit Results";
            this.buttonEditResults.UseVisualStyleBackColor = true;
            this.buttonEditResults.Click += new System.EventHandler(this.buttonEditResults_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Order Lab Test";
            // 
            // comboBoxTestOrder
            // 
            this.comboBoxTestOrder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTestOrder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTestOrder.FormattingEnabled = true;
            this.comboBoxTestOrder.Location = new System.Drawing.Point(88, 4);
            this.comboBoxTestOrder.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTestOrder.Name = "comboBoxTestOrder";
            this.comboBoxTestOrder.Size = new System.Drawing.Size(418, 21);
            this.comboBoxTestOrder.TabIndex = 4;
            // 
            // buttonAddTestToOrder
            // 
            this.buttonAddTestToOrder.Location = new System.Drawing.Point(511, 4);
            this.buttonAddTestToOrder.Name = "buttonAddTestToOrder";
            this.buttonAddTestToOrder.Size = new System.Drawing.Size(80, 23);
            this.buttonAddTestToOrder.TabIndex = 5;
            this.buttonAddTestToOrder.Text = "Add to Order";
            this.buttonAddTestToOrder.UseVisualStyleBackColor = true;
            this.buttonAddTestToOrder.Click += new System.EventHandler(this.buttonAddTestToOrder_Click);
            // 
            // buttonSubmitOrder
            // 
            this.buttonSubmitOrder.Location = new System.Drawing.Point(426, 374);
            this.buttonSubmitOrder.Name = "buttonSubmitOrder";
            this.buttonSubmitOrder.Size = new System.Drawing.Size(80, 23);
            this.buttonSubmitOrder.TabIndex = 6;
            this.buttonSubmitOrder.Text = "Submit Order";
            this.buttonSubmitOrder.UseVisualStyleBackColor = true;
            this.buttonSubmitOrder.Click += new System.EventHandler(this.buttonSubmitOrder_Click);
            // 
            // dateTimePickerTest
            // 
            this.dateTimePickerTest.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTest.Location = new System.Drawing.Point(232, 214);
            this.dateTimePickerTest.Name = "dateTimePickerTest";
            this.dateTimePickerTest.Size = new System.Drawing.Size(162, 20);
            this.dateTimePickerTest.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date/Time Taken";
            // 
            // buttonRemoveTest
            // 
            this.buttonRemoveTest.Location = new System.Drawing.Point(8, 374);
            this.buttonRemoveTest.Name = "buttonRemoveTest";
            this.buttonRemoveTest.Size = new System.Drawing.Size(141, 23);
            this.buttonRemoveTest.TabIndex = 7;
            this.buttonRemoveTest.Text = "Remove Test from Order";
            this.buttonRemoveTest.UseVisualStyleBackColor = true;
            this.buttonRemoveTest.Click += new System.EventHandler(this.buttonRemoveTest_Click);
            // 
            // Labs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 656);
            this.Controls.Add(this.buttonRemoveTest);
            this.Controls.Add(this.buttonSubmitOrder);
            this.Controls.Add(this.buttonAddTestToOrder);
            this.Controls.Add(this.comboBoxTestOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEditResults);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.listViewTests);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Labs";
            this.Text = "Labs";
            this.groupBoxResults.ResumeLayout(false);
            this.groupBoxResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewTests;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.TextBox textBoxResults;
        private System.Windows.Forms.Button buttonCancelEditResults;
        private System.Windows.Forms.Button buttonSaveResults;
        private System.Windows.Forms.CheckBox checkBoxAbnormal;
        private System.Windows.Forms.Button buttonEditResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTestOrder;
        private System.Windows.Forms.Button buttonAddTestToOrder;
        private System.Windows.Forms.Button buttonSubmitOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTest;
        private System.Windows.Forms.Button buttonRemoveTest;
    }
}