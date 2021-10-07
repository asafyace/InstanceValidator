
namespace InstanceValidator
{
    partial class InstanceValidatorForm
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
            this.textDbInstances = new System.Windows.Forms.TextBox();
            this.textLocalInstances = new System.Windows.Forms.TextBox();
            this.getDbInstance = new System.Windows.Forms.Button();
            this.getLocalInstance = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ChangeInstance = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textDbInstances
            // 
            this.textDbInstances.Location = new System.Drawing.Point(363, 51);
            this.textDbInstances.Multiline = true;
            this.textDbInstances.Name = "textDbInstances";
            this.textDbInstances.Size = new System.Drawing.Size(236, 383);
            this.textDbInstances.TabIndex = 7;
            // 
            // textLocalInstances
            // 
            this.textLocalInstances.Location = new System.Drawing.Point(34, 51);
            this.textLocalInstances.Multiline = true;
            this.textLocalInstances.Name = "textLocalInstances";
            this.textLocalInstances.Size = new System.Drawing.Size(236, 383);
            this.textLocalInstances.TabIndex = 6;
            // 
            // getDbInstance
            // 
            this.getDbInstance.Location = new System.Drawing.Point(446, 470);
            this.getDbInstance.Name = "getDbInstance";
            this.getDbInstance.Size = new System.Drawing.Size(80, 36);
            this.getDbInstance.TabIndex = 5;
            this.getDbInstance.Text = "Get DB Instances";
            this.getDbInstance.UseVisualStyleBackColor = true;
            this.getDbInstance.Click += new System.EventHandler(this.getDbInstance_Click);
            // 
            // getLocalInstance
            // 
            this.getLocalInstance.Location = new System.Drawing.Point(96, 470);
            this.getLocalInstance.Name = "getLocalInstance";
            this.getLocalInstance.Size = new System.Drawing.Size(80, 36);
            this.getLocalInstance.TabIndex = 4;
            this.getLocalInstance.Text = "Get Folder Instances";
            this.getLocalInstance.UseVisualStyleBackColor = true;
            this.getLocalInstance.Click += new System.EventHandler(this.getLocalInstance_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(239, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ChangeInstance);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(619, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose folder and change instance id";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(63, 20);
            this.textBox1.TabIndex = 9;
            // 
            // ChangeInstance
            // 
            this.ChangeInstance.Location = new System.Drawing.Point(182, 71);
            this.ChangeInstance.Name = "ChangeInstance";
            this.ChangeInstance.Size = new System.Drawing.Size(63, 23);
            this.ChangeInstance.TabIndex = 10;
            this.ChangeInstance.Text = "Change";
            this.ChangeInstance.UseVisualStyleBackColor = true;
            this.ChangeInstance.Click += new System.EventHandler(this.ChangeInstance_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "New Instance ID";
            // 
            // InstanceValidatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 565);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textDbInstances);
            this.Controls.Add(this.textLocalInstances);
            this.Controls.Add(this.getDbInstance);
            this.Controls.Add(this.getLocalInstance);
            this.Name = "InstanceValidatorForm";
            this.Text = "Instance Validator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textDbInstances;
        private System.Windows.Forms.TextBox textLocalInstances;
        private System.Windows.Forms.Button getDbInstance;
        private System.Windows.Forms.Button getLocalInstance;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ChangeInstance;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

