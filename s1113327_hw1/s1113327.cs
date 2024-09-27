using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s1113327_hw1 {
    public partial class s1113327 : Form {
        private Button[] b;
        private int[] matrix = new int[25];
        public s1113327() {
            InitializeComponent();
            InitializeButtons();
            InitializeMatrix();
        }
        private void s1113327_Load(object sender, EventArgs e) {}
        private void InitializeButtons() {
            b = new Button[25];
            int buttonSize = 50, margin = 10, rows = 5, columns = 5;
            for (int i = 0; i < 25; i++) {
                b[i] = new Button();
                b[i].Text = i.ToString();
                b[i].Width = buttonSize;
                b[i].Height = buttonSize;
                b[i].Tag = i; // 將索引存儲在Tag屬性中
                b[i].Location = new Point((i % columns) * (buttonSize + margin), (i / rows) * (buttonSize + margin));
                b[i].Click += new EventHandler(Button_Click);
                this.Controls.Add(b[i]);
            }
        }
        private void InitializeMatrix() {
            for (int i = 0; i < 25; i++) {
                matrix[i] = (i == 12) ? 1 : 0; // Default: Button 12 is blue, others are red
                UpdateButtonColor(i);
            }
        }
        private void Button_Click(object sender, EventArgs e) {
            Button clickedButton = (Button)sender;
            int index = (int)clickedButton.Tag;// 從Tag屬性中獲取索引
            matrix[index] = 1 - matrix[index]; // Toggle the button's color (0 to 1 or 1 to 0)

            // Toggle the adjacent buttons' color (up, down, left, right)
            buttonInfluence(index - 5); // Up
            buttonInfluence(index + 5); // Down
            if (index % 5 != 0) buttonInfluence(index - 1); // Left (if not on the left edge)
            if (index % 5 != 4) buttonInfluence(index + 1); // Right (if not on the right edge)
            UpdateButtonColor(index);
        }
        private void buttonInfluence(int i) {
            if (i >= 0 && i < 25) {
                matrix[i] = 1 - matrix[i];
                UpdateButtonColor(i);
            }
        }
        private void UpdateButtonColor(int i) {
            if (matrix[i] == 1)
                b[i].BackColor = Color.Blue;
            else
                b[i].BackColor = Color.Red;
        }
    }
}