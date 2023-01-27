namespace Игра
{
    partial class Menu
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
            this.StartGameButton = new System.Windows.Forms.Button();
            this.CloseGameButton = new System.Windows.Forms.Button();
            this.Background = new System.Windows.Forms.Panel();
            this.RecordButton = new System.Windows.Forms.Button();
            this.GameName = new System.Windows.Forms.Label();
            this.Background.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartGameButton
            // 
            this.StartGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartGameButton.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StartGameButton.Location = new System.Drawing.Point(348, 224);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(305, 91);
            this.StartGameButton.TabIndex = 0;
            this.StartGameButton.Text = "Начать игру";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // CloseGameButton
            // 
            this.CloseGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseGameButton.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloseGameButton.Location = new System.Drawing.Point(348, 472);
            this.CloseGameButton.Name = "CloseGameButton";
            this.CloseGameButton.Size = new System.Drawing.Size(305, 91);
            this.CloseGameButton.TabIndex = 1;
            this.CloseGameButton.Text = "Выйти";
            this.CloseGameButton.UseVisualStyleBackColor = true;
            this.CloseGameButton.Click += new System.EventHandler(this.CloseGameButton_Click);
            // 
            // Background
            // 
            this.Background.Controls.Add(this.GameName);
            this.Background.Controls.Add(this.RecordButton);
            this.Background.Controls.Add(this.StartGameButton);
            this.Background.Controls.Add(this.CloseGameButton);
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(1000, 600);
            this.Background.TabIndex = 2;
            this.Background.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Background_MouseDown);
            this.Background.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Background_MouseMove);
            // 
            // RecordButton
            // 
            this.RecordButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RecordButton.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RecordButton.Location = new System.Drawing.Point(348, 350);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(305, 91);
            this.RecordButton.TabIndex = 2;
            this.RecordButton.Text = "Миллионеры";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // GameName
            // 
            this.GameName.AutoSize = true;
            this.GameName.Font = new System.Drawing.Font("Segoe UI Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GameName.Location = new System.Drawing.Point(338, 48);
            this.GameName.Name = "GameName";
            this.GameName.Size = new System.Drawing.Size(325, 86);
            this.GameName.TabIndex = 3;
            this.GameName.Text = "Millioner";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.Background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Background.ResumeLayout(false);
            this.Background.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button StartGameButton;
        private Button CloseGameButton;
        private Panel Background;
        private Button RecordButton;
        private Label GameName;
    }
}