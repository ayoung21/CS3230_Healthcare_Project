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
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTest = new System.Windows.Forms.DateTimePicker();
            this.buttonCancelEditResults = new System.Windows.Forms.Button();
            this.buttonSaveResults = new System.Windows.Forms.Button();
            this.checkBoxAbnormal = new System.Windows.Forms.CheckBox();
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.buttonEditResults = new System.Windows.Forms.Button();
            this.comboBoxTestOrder = new System.Windows.Forms.ComboBox();
            this.buttonAddTestToOrder = new System.Windows.Forms.Button();
            this.buttonSubmitOrder = new System.Windows.Forms.Button();
            this.buttonRemoveTest = new System.Windows.Forms.Button();
            this.groupBoxOrderTest = new System.Windows.Forms.GroupBox();
            this.groupBoxResults.SuspendLayout();
            this.groupBoxOrderTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewTests
            // 
            this.listViewTests.HideSelection = false;
            this.listViewTests.Location = new System.Drawing.Point(11, 63);
            this.listViewTests.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewTests.MultiSelect = false;
            this.listViewTests.Name = "listViewTests";
            this.listViewTests.Size = new System.Drawing.Size(777, 392);
            this.listViewTests.TabIndex = 0;
            this.listViewTests.UseCompatibleStateImageBehavior = false;
            this.listViewTests.View = System.Windows.Forms.View.Details;
            this.listViewTests.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewTests_MouseUp);
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
            this.groupBoxResults.Location = new System.Drawing.Point(11, 495);
            this.groupBoxResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxResults.Size = new System.Drawing.Size(779, 300);
            this.groupBoxResults.TabIndex = 1;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Results";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 268);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date/Time Taken";
            // 
            // dateTimePickerTest
            // 
            this.dateTimePickerTest.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTest.Location = new System.Drawing.Point(309, 263);
            this.dateTimePickerTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerTest.Name = "dateTimePickerTest";
            this.dateTimePickerTest.Size = new System.Drawing.Size(215, 22);
            this.dateTimePickerTest.TabIndex = 4;
            // 
            // buttonCancelEditResults
            // 
            this.buttonCancelEditResults.Location = new System.Drawing.Point(617, 265);
            this.buttonCancelEditResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancelEditResults.Name = "buttonCancelEditResults";
            this.buttonCancelEditResults.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelEditResults.TabIndex = 3;
            this.buttonCancelEditResults.Text = "Cancel";
            this.buttonCancelEditResults.UseVisualStyleBackColor = true;
            this.buttonCancelEditResults.Click += new System.EventHandler(this.buttonCancelEditResults_Click);
            // 
            // buttonSaveResults
            // 
            this.buttonSaveResults.Location = new System.Drawing.Point(697, 265);
            this.buttonSaveResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSaveResults.Name = "buttonSaveResults";
            this.buttonSaveResults.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveResults.TabIndex = 2;
            this.buttonSaveResults.Text = "Save";
            this.buttonSaveResults.UseVisualStyleBackColor = true;
            this.buttonSaveResults.Click += new System.EventHandler(this.buttonSaveResults_Click);
            // 
            // checkBoxAbnormal
            // 
            this.checkBoxAbnormal.Location = new System.Drawing.Point(5, 265);
            this.checkBoxAbnormal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxAbnormal.Name = "checkBoxAbnormal";
            this.checkBoxAbnormal.Size = new System.Drawing.Size(116, 21);
            this.checkBoxAbnormal.TabIndex = 1;
            this.checkBoxAbnormal.Text = "Is abnormal";
            this.checkBoxAbnormal.UseVisualStyleBackColor = true;
            // 
            // textBoxResults
            // 
            this.textBoxResults.Location = new System.Drawing.Point(5, 21);
            this.textBoxResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxResults.MaxLength = 200;
            this.textBoxResults.Multiline = true;
            this.textBoxResults.Name = "textBoxResults";
            this.textBoxResults.Size = new System.Drawing.Size(767, 229);
            this.textBoxResults.TabIndex = 0;
            // 
            // buttonEditResults
            // 
            this.buttonEditResults.Location = new System.Drawing.Point(681, 460);
            this.buttonEditResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEditResults.Name = "buttonEditResults";
            this.buttonEditResults.Size = new System.Drawing.Size(107, 28);
            this.buttonEditResults.TabIndex = 2;
            this.buttonEditResults.Text = "Edit Results";
            this.buttonEditResults.UseVisualStyleBackColor = true;
            this.buttonEditResults.Click += new System.EventHandler(this.buttonEditResults_Click);
            // 
            // comboBoxTestOrder
            // 
            this.comboBoxTestOrder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTestOrder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTestOrder.FormattingEnabled = true;
            this.comboBoxTestOrder.Location = new System.Drawing.Point(7, 20);
            this.comboBoxTestOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTestOrder.Name = "comboBoxTestOrder";
            this.comboBoxTestOrder.Size = new System.Drawing.Size(649, 24);
            this.comboBoxTestOrder.TabIndex = 4;
            // 
            // buttonAddTestToOrder
            // 
            this.buttonAddTestToOrder.Location = new System.Drawing.Point(664, 20);
            this.buttonAddTestToOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAddTestToOrder.Name = "buttonAddTestToOrder";
            this.buttonAddTestToOrder.Size = new System.Drawing.Size(107, 28);
            this.buttonAddTestToOrder.TabIndex = 5;
            this.buttonAddTestToOrder.Text = "Add to Order";
            this.buttonAddTestToOrder.UseVisualStyleBackColor = true;
            this.buttonAddTestToOrder.Click += new System.EventHandler(this.buttonAddTestToOrder_Click);
            // 
            // buttonSubmitOrder
            // 
            this.buttonSubmitOrder.Location = new System.Drawing.Point(681, 462);
            this.buttonSubmitOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSubmitOrder.Name = "buttonSubmitOrder";
            this.buttonSubmitOrder.Size = new System.Drawing.Size(107, 28);
            this.buttonSubmitOrder.TabIndex = 6;
            this.buttonSubmitOrder.Text = "Submit Order";
            this.buttonSubmitOrder.UseVisualStyleBackColor = true;
            this.buttonSubmitOrder.Click += new System.EventHandler(this.buttonSubmitOrder_Click);
            // 
            // buttonRemoveTest
            // 
            this.buttonRemoveTest.Location = new System.Drawing.Point(485, 462);
            this.buttonRemoveTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRemoveTest.Name = "buttonRemoveTest";
            this.buttonRemoveTest.Size = new System.Drawing.Size(188, 28);
            this.buttonRemoveTest.TabIndex = 7;
            this.buttonRemoveTest.Text = "Remove Test from Order";
            this.buttonRemoveTest.UseVisualStyleBackColor = true;
            this.buttonRemoveTest.Click += new System.EventHandler(this.buttonRemoveTest_Click);
            // 
            // groupBoxOrderTest
            // 
            this.groupBoxOrderTest.Controls.Add(this.comboBoxTestOrder);
            this.groupBoxOrderTest.Controls.Add(this.buttonAddTestToOrder);
            this.groupBoxOrderTest.Location = new System.Drawing.Point(11, 4);
            this.groupBoxOrderTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxOrderTest.Name = "groupBoxOrderTest";
            this.groupBoxOrderTest.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxOrderTest.Size = new System.Drawing.Size(779, 53);
            this.groupBoxOrderTest.TabIndex = 8;
            this.groupBoxOrderTest.TabStop = false;
            this.groupBoxOrderTest.Text = "Order Lab Test";
            // 
            // Labs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 904);
            this.Controls.Add(this.groupBoxOrderTest);
            this.Controls.Add(this.buttonRemoveTest);
            this.Controls.Add(this.buttonSubmitOrder);
            this.Controls.Add(this.buttonEditResults);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.listViewTests);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Labs";
            this.Text = "Labs";
            this.groupBoxResults.ResumeLayout(false);
            this.groupBoxResults.PerformLayout();
            this.groupBoxOrderTest.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox comboBoxTestOrder;
        private System.Windows.Forms.Button buttonAddTestToOrder;
        private System.Windows.Forms.Button buttonSubmitOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTest;
        private System.Windows.Forms.Button buttonRemoveTest;
        private System.Windows.Forms.GroupBox groupBoxOrderTest;
    }
}