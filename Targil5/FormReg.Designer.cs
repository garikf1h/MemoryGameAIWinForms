namespace Targil5
{
    partial class FormReg
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
            this.m_AgainstAFriend = new System.Windows.Forms.Button();
            this.m_FirstPlayerNameLabel = new System.Windows.Forms.Label();
            this.m_SecondPlayerName = new System.Windows.Forms.Label();
            this.m_NameOfFirstPlayer = new System.Windows.Forms.TextBox();
            this.m_NameOfSecondPlayer = new System.Windows.Forms.TextBox();
            this.m_SizeOfBoard = new System.Windows.Forms.Button();
            this.m_Start = new System.Windows.Forms.Button();
            this.m_BoardSizeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_AgainstAFriend
            // 
            this.m_AgainstAFriend.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_AgainstAFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_AgainstAFriend.Location = new System.Drawing.Point(350, 51);
            this.m_AgainstAFriend.Name = "m_AgainstAFriend";
            this.m_AgainstAFriend.Size = new System.Drawing.Size(130, 34);
            this.m_AgainstAFriend.TabIndex = 0;
            this.m_AgainstAFriend.Text = "Against A Friend";
            this.m_AgainstAFriend.UseVisualStyleBackColor = true;
            this.m_AgainstAFriend.Click += new System.EventHandler(this.m_AgainstAFriend_Click);
            // 
            // m_FirstPlayerNameLabel
            // 
            this.m_FirstPlayerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_FirstPlayerNameLabel.Location = new System.Drawing.Point(15, 25);
            this.m_FirstPlayerNameLabel.Name = "m_FirstPlayerNameLabel";
            this.m_FirstPlayerNameLabel.Size = new System.Drawing.Size(108, 19);
            this.m_FirstPlayerNameLabel.TabIndex = 1;
            this.m_FirstPlayerNameLabel.Text = "First Player Name:";
            // 
            // m_SecondPlayerName
            // 
            this.m_SecondPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_SecondPlayerName.Location = new System.Drawing.Point(15, 58);
            this.m_SecondPlayerName.Name = "m_SecondPlayerName";
            this.m_SecondPlayerName.Size = new System.Drawing.Size(156, 34);
            this.m_SecondPlayerName.TabIndex = 2;
            this.m_SecondPlayerName.Text = "Second Player Name:";
            this.m_SecondPlayerName.Click += new System.EventHandler(this.m_SecondPlayerName_Click);
            // 
            // m_NameOfFirstPlayer
            // 
            this.m_NameOfFirstPlayer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_NameOfFirstPlayer.Location = new System.Drawing.Point(197, 22);
            this.m_NameOfFirstPlayer.Name = "m_NameOfFirstPlayer";
            this.m_NameOfFirstPlayer.Size = new System.Drawing.Size(130, 22);
            this.m_NameOfFirstPlayer.TabIndex = 3;
            // 
            // m_NameOfSecondPlayer
            // 
            this.m_NameOfSecondPlayer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_NameOfSecondPlayer.Enabled = false;
            this.m_NameOfSecondPlayer.Location = new System.Drawing.Point(197, 58);
            this.m_NameOfSecondPlayer.Name = "m_NameOfSecondPlayer";
            this.m_NameOfSecondPlayer.Size = new System.Drawing.Size(130, 22);
            this.m_NameOfSecondPlayer.TabIndex = 4;
            this.m_NameOfSecondPlayer.Text = "-PC-";
            // 
            // m_SizeOfBoard
            // 
            this.m_SizeOfBoard.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_SizeOfBoard.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_SizeOfBoard.Location = new System.Drawing.Point(12, 132);
            this.m_SizeOfBoard.Name = "m_SizeOfBoard";
            this.m_SizeOfBoard.Size = new System.Drawing.Size(105, 91);
            this.m_SizeOfBoard.TabIndex = 5;
            this.m_SizeOfBoard.Text = "4X4";
            this.m_SizeOfBoard.UseVisualStyleBackColor = false;
            this.m_SizeOfBoard.Click += new System.EventHandler(this.m_SizeOfBoard_Click);
            // 
            // m_Start
            // 
            this.m_Start.BackColor = System.Drawing.Color.Aqua;
            this.m_Start.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_Start.Location = new System.Drawing.Point(345, 182);
            this.m_Start.Name = "m_Start";
            this.m_Start.Size = new System.Drawing.Size(135, 41);
            this.m_Start.TabIndex = 6;
            this.m_Start.TabStop = false;
            this.m_Start.Text = "Start!";
            this.m_Start.UseVisualStyleBackColor = false;
            this.m_Start.Click += new System.EventHandler(this.m_Start_Click);
            // 
            // m_BoardSizeLabel
            // 
            this.m_BoardSizeLabel.AutoSize = true;
            this.m_BoardSizeLabel.Location = new System.Drawing.Point(15, 112);
            this.m_BoardSizeLabel.Name = "m_BoardSizeLabel";
            this.m_BoardSizeLabel.Size = new System.Drawing.Size(81, 17);
            this.m_BoardSizeLabel.TabIndex = 7;
            this.m_BoardSizeLabel.Text = "Board Size:";
            // 
            // FormReg
            // 
            this.AcceptButton = this.m_Start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 235);
            this.Controls.Add(this.m_BoardSizeLabel);
            this.Controls.Add(this.m_Start);
            this.Controls.Add(this.m_SizeOfBoard);
            this.Controls.Add(this.m_NameOfSecondPlayer);
            this.Controls.Add(this.m_NameOfFirstPlayer);
            this.Controls.Add(this.m_SecondPlayerName);
            this.Controls.Add(this.m_FirstPlayerNameLabel);
            this.Controls.Add(this.m_AgainstAFriend);
            this.KeyPreview = true;
            this.Name = "FormReg";
            this.Text = "MemoryGame - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_AgainstAFriend;
        private System.Windows.Forms.Label m_FirstPlayerNameLabel;
        private System.Windows.Forms.Label m_SecondPlayerName;
        private System.Windows.Forms.TextBox m_NameOfFirstPlayer;
        private System.Windows.Forms.TextBox m_NameOfSecondPlayer;
        private System.Windows.Forms.Button m_SizeOfBoard;
        private System.Windows.Forms.Button m_Start;
        private System.Windows.Forms.Label m_BoardSizeLabel;
    }
}

