namespace ToDoList
{
    partial class Напоминалка
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxAction = new System.Windows.Forms.TextBox();
            this.labelAction = new System.Windows.Forms.Label();
            this.textBoxDateTime = new System.Windows.Forms.TextBox();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.buttonQuestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(603, 94);
            this.checkedListBox1.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(351, 124);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(264, 23);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Удалить запись/записи";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(12, 221);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(603, 23);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Добавить запись";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(12, 124);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(277, 23);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Редактировать запись";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(12, 185);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(171, 20);
            this.textBoxTitle.TabIndex = 4;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(13, 166);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(108, 13);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "Тема напоминания:";
            // 
            // textBoxAction
            // 
            this.textBoxAction.Location = new System.Drawing.Point(234, 185);
            this.textBoxAction.Name = "textBoxAction";
            this.textBoxAction.Size = new System.Drawing.Size(171, 20);
            this.textBoxAction.TabIndex = 6;
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Location = new System.Drawing.Point(234, 165);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(154, 13);
            this.labelAction.TabIndex = 7;
            this.labelAction.Text = "Действия (раскрытие темы):";
            // 
            // textBoxDateTime
            // 
            this.textBoxDateTime.Location = new System.Drawing.Point(444, 184);
            this.textBoxDateTime.Name = "textBoxDateTime";
            this.textBoxDateTime.Size = new System.Drawing.Size(171, 20);
            this.textBoxDateTime.TabIndex = 8;
            this.textBoxDateTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDateTime_KeyPress);
            // 
            // labelDateTime
            // 
            this.labelDateTime.AutoSize = true;
            this.labelDateTime.Location = new System.Drawing.Point(444, 164);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(80, 13);
            this.labelDateTime.TabIndex = 9;
            this.labelDateTime.Text = "Дата и время:";
            // 
            // buttonQuestion
            // 
            this.buttonQuestion.Location = new System.Drawing.Point(585, 154);
            this.buttonQuestion.Name = "buttonQuestion";
            this.buttonQuestion.Size = new System.Drawing.Size(30, 23);
            this.buttonQuestion.TabIndex = 10;
            this.buttonQuestion.Text = "?";
            this.buttonQuestion.UseVisualStyleBackColor = true;
            this.buttonQuestion.Click += new System.EventHandler(this.buttonQuestion_Click);
            // 
            // Напоминалка
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 258);
            this.Controls.Add(this.buttonQuestion);
            this.Controls.Add(this.labelDateTime);
            this.Controls.Add(this.textBoxDateTime);
            this.Controls.Add(this.labelAction);
            this.Controls.Add(this.textBoxAction);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.checkedListBox1);
            this.MaximumSize = new System.Drawing.Size(650, 297);
            this.MinimumSize = new System.Drawing.Size(650, 297);
            this.Name = "Напоминалка";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxAction;
        private System.Windows.Forms.Label labelAction;
        private System.Windows.Forms.TextBox textBoxDateTime;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.Button buttonQuestion;
    }
}

