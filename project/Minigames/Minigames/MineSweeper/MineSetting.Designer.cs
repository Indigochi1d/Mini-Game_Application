using System.Windows.Forms;

namespace MineSweeper
{
    partial class Mine_Setting_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mineform = new System.Windows.Forms.Button();
            this.mine_num_updown = new System.Windows.Forms.NumericUpDown();
            this.mine_num_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mine_num_updown)).BeginInit();
            this.SuspendLayout();
            // 
            // mineform
            // 
            this.mineform.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mineform.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.mineform.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mineform.Location = new System.Drawing.Point(46, 40);
            this.mineform.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mineform.Name = "mineform";
            this.mineform.Size = new System.Drawing.Size(170, 65);
            this.mineform.TabIndex = 1;
            this.mineform.Text = "지뢰찾기 시작!";
            this.mineform.UseVisualStyleBackColor = false;
            this.mineform.Click += new System.EventHandler(this.mineform_Click);
            // 
            // mine_num_updown
            // 
            this.mine_num_updown.Location = new System.Drawing.Point(159, 126);
            this.mine_num_updown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mine_num_updown.Name = "mine_num_updown";
            this.mine_num_updown.Size = new System.Drawing.Size(57, 21);
            this.mine_num_updown.TabIndex = 2;
            this.mine_num_updown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // mine_num_label
            // 
            this.mine_num_label.AutoSize = true;
            this.mine_num_label.Location = new System.Drawing.Point(44, 128);
            this.mine_num_label.Name = "mine_num_label";
            this.mine_num_label.Size = new System.Drawing.Size(104, 12);
            this.mine_num_label.TabIndex = 3;
            this.mine_num_label.Text = "지뢰 개수 (1~100)";
            // 
            // Mine_Setting_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(255, 182);
            this.Controls.Add(this.mine_num_label);
            this.Controls.Add(this.mine_num_updown);
            this.Controls.Add(this.mineform);
            this.Location = new System.Drawing.Point(800, 500);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Mine_Setting_Form";
            this.Text = "지뢰찾기 설정";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mine_num_updown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button mineform;
        private NumericUpDown mine_num_updown;
        private Label mine_num_label;
    }
}