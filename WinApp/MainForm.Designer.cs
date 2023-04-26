namespace WinApp
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            TrainYourselfPage = new TabPage();
            DeleteWordButton = new Button();
            DisplayTranslationTextBox = new TextBox();
            ShowNextButton = new Button();
            ShowTranslationButton = new Button();
            DisplayWordTextBox = new TextBox();
            AddNewWordsPage = new TabPage();
            AddDataButton = new Button();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            InputTranslationTextBox = new TextBox();
            InputWordTextBox = new TextBox();
            addWordsErrorProvider = new ErrorProvider(components);
            tabControl1.SuspendLayout();
            TrainYourselfPage.SuspendLayout();
            AddNewWordsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)addWordsErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TrainYourselfPage);
            tabControl1.Controls.Add(AddNewWordsPage);
            tabControl1.Location = new Point(2, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(799, 363);
            tabControl1.TabIndex = 0;
            // 
            // TrainYourselfPage
            // 
            TrainYourselfPage.BackColor = Color.Transparent;
            TrainYourselfPage.Controls.Add(DeleteWordButton);
            TrainYourselfPage.Controls.Add(DisplayTranslationTextBox);
            TrainYourselfPage.Controls.Add(ShowNextButton);
            TrainYourselfPage.Controls.Add(ShowTranslationButton);
            TrainYourselfPage.Controls.Add(DisplayWordTextBox);
            TrainYourselfPage.ForeColor = Color.Black;
            TrainYourselfPage.Location = new Point(4, 35);
            TrainYourselfPage.Name = "TrainYourselfPage";
            TrainYourselfPage.Padding = new Padding(3);
            TrainYourselfPage.Size = new Size(791, 324);
            TrainYourselfPage.TabIndex = 0;
            TrainYourselfPage.Text = "Train yourself!";
            TrainYourselfPage.Enter += TrainYourselfPage_Enter;
            // 
            // DeleteWordButton
            // 
            DeleteWordButton.Location = new Point(314, 269);
            DeleteWordButton.Name = "DeleteWordButton";
            DeleteWordButton.Size = new Size(189, 42);
            DeleteWordButton.TabIndex = 4;
            DeleteWordButton.Text = "Delete";
            DeleteWordButton.UseVisualStyleBackColor = true;
            DeleteWordButton.Click += DeleteWordButton_Click;
            // 
            // DisplayTranslationTextBox
            // 
            DisplayTranslationTextBox.BackColor = SystemColors.Control;
            DisplayTranslationTextBox.Font = new Font("Comic Sans MS", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            DisplayTranslationTextBox.Location = new Point(101, 123);
            DisplayTranslationTextBox.Name = "DisplayTranslationTextBox";
            DisplayTranslationTextBox.ReadOnly = true;
            DisplayTranslationTextBox.Size = new Size(609, 45);
            DisplayTranslationTextBox.TabIndex = 3;
            DisplayTranslationTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ShowNextButton
            // 
            ShowNextButton.Location = new Point(435, 199);
            ShowNextButton.Name = "ShowNextButton";
            ShowNextButton.Size = new Size(275, 42);
            ShowNextButton.TabIndex = 2;
            ShowNextButton.Text = "I remember!";
            ShowNextButton.UseVisualStyleBackColor = true;
            ShowNextButton.Click += ShowNextButton_Click;
            // 
            // ShowTranslationButton
            // 
            ShowTranslationButton.Location = new Point(101, 199);
            ShowTranslationButton.Name = "ShowTranslationButton";
            ShowTranslationButton.Size = new Size(275, 42);
            ShowTranslationButton.TabIndex = 1;
            ShowTranslationButton.Text = "Translation";
            ShowTranslationButton.UseVisualStyleBackColor = true;
            ShowTranslationButton.Click += ShowTranslationButton_Click;
            // 
            // DisplayWordTextBox
            // 
            DisplayWordTextBox.Font = new Font("Comic Sans MS", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            DisplayWordTextBox.Location = new Point(101, 57);
            DisplayWordTextBox.Name = "DisplayWordTextBox";
            DisplayWordTextBox.ReadOnly = true;
            DisplayWordTextBox.Size = new Size(609, 45);
            DisplayWordTextBox.TabIndex = 0;
            DisplayWordTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // AddNewWordsPage
            // 
            AddNewWordsPage.BackColor = Color.Transparent;
            AddNewWordsPage.Controls.Add(AddDataButton);
            AddNewWordsPage.Controls.Add(label4);
            AddNewWordsPage.Controls.Add(label2);
            AddNewWordsPage.Controls.Add(label1);
            AddNewWordsPage.Controls.Add(InputTranslationTextBox);
            AddNewWordsPage.Controls.Add(InputWordTextBox);
            AddNewWordsPage.ForeColor = Color.Black;
            AddNewWordsPage.Location = new Point(4, 35);
            AddNewWordsPage.Name = "AddNewWordsPage";
            AddNewWordsPage.Padding = new Padding(3);
            AddNewWordsPage.Size = new Size(791, 324);
            AddNewWordsPage.TabIndex = 1;
            AddNewWordsPage.Text = "Add new words!";
            // 
            // AddDataButton
            // 
            AddDataButton.BackColor = Color.Transparent;
            AddDataButton.ForeColor = Color.Black;
            AddDataButton.Location = new Point(38, 244);
            AddDataButton.Name = "AddDataButton";
            AddDataButton.Size = new Size(723, 54);
            AddDataButton.TabIndex = 7;
            AddDataButton.Text = "Add the data!";
            AddDataButton.UseVisualStyleBackColor = false;
            AddDataButton.Click += addDataButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 23);
            label4.Name = "label4";
            label4.Size = new Size(140, 26);
            label4.TabIndex = 6;
            label4.Text = "Enter here the";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 114);
            label2.Name = "label2";
            label2.Size = new Size(110, 26);
            label2.TabIndex = 4;
            label2.Text = "Translation";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 67);
            label1.Name = "label1";
            label1.Size = new Size(135, 26);
            label1.TabIndex = 3;
            label1.Text = "Word to learn";
            // 
            // InputTranslationTextBox
            // 
            InputTranslationTextBox.Location = new Point(168, 114);
            InputTranslationTextBox.Name = "InputTranslationTextBox";
            InputTranslationTextBox.Size = new Size(593, 34);
            InputTranslationTextBox.TabIndex = 1;
            InputTranslationTextBox.Tag = "translation";
            InputTranslationTextBox.TextChanged += TextBox_Validating;
            // 
            // InputWordTextBox
            // 
            InputWordTextBox.Location = new Point(168, 64);
            InputWordTextBox.Name = "InputWordTextBox";
            InputWordTextBox.Size = new Size(593, 34);
            InputWordTextBox.TabIndex = 0;
            InputWordTextBox.Tag = "word to learn";
            InputWordTextBox.TextChanged += TextBox_Validating;
            // 
            // addWordsErrorProvider
            // 
            addWordsErrorProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(804, 361);
            Controls.Add(tabControl1);
            Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.White;
            Location = new Point(800, 1300);
            Margin = new Padding(5, 6, 5, 6);
            MaximumSize = new Size(820, 400);
            MinimumSize = new Size(820, 400);
            Name = "MainForm";
            Text = "DictionaryTrainer";
            tabControl1.ResumeLayout(false);
            TrainYourselfPage.ResumeLayout(false);
            TrainYourselfPage.PerformLayout();
            AddNewWordsPage.ResumeLayout(false);
            AddNewWordsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)addWordsErrorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage TrainYourselfPage;
        private TabPage AddNewWordsPage;
        private Button AddDataButton;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox InputTranslationTextBox;
        private TextBox InputWordTextBox;
        private ErrorProvider addWordsErrorProvider;
        private TextBox DisplayWordTextBox;
        private Button ShowNextButton;
        private Button ShowTranslationButton;
        private TextBox DisplayTranslationTextBox;
        private Button DeleteWordButton;
    }
}