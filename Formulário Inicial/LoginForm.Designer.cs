namespace Formulário_Inicial
{
    partial class LoginForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(90, 34);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(197, 20);
            this.userTextBox.TabIndex = 1;
            this.userTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(10, 34);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(55, 13);
            this.Username.TabIndex = 2;
            this.Username.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(90, 76);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(197, 20);
            this.passTextBox.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 151);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.button1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Button button2;
    }
}