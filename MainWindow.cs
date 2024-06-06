using System;
using System.Windows.Forms;
using CalculationСostsProgram.Properties;

namespace CalculationСostsProgram
{
    public partial class MainWindow : Form
    {
        private static ComboBox[] tempCBox;

        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void button_ClearSettingsClick(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    c.Text = string.Empty;
                }

                if (c.GetType() == typeof(ComboBox))
                {
                    ComboBox cb = (ComboBox)c;
                    cb.SelectedIndex = -1;
                }
            }
        }
        
        private void LoadSettings()
        {
            ComboBox[] tempBoxs = {
                    predictability_CB, devFlexibility_CB, permissionRisk_CB, Connectivity_CB, maturity_CB,
                    RELY_CB, DATA_CB, CPLX_CB, RUSE_CB, DOCU_CB,
                    TIME_CB, STOR_CB, PVOL_CB, ACAP_CB, PCAP_CB,
                    PCON_CB, AEXP_CB, PEXP_CB, LTEX_CB, TOOL_CB,
                    SITE_CB, SCED_CB
            };

            tempCBox = tempBoxs;

            string[] tempArr = Settings.Default.settingsCB.Split(' ');
            for (int i = 0; i < tempArr.Length - 1; i++)
            {
                tempCBox[i].SelectedIndex = int.Parse(tempArr[i]);
            }
        }

        private void SaveSettings() {
            string saveSettings = "";
            foreach(var item in tempCBox)
            {
                saveSettings += item.SelectedIndex.ToString() + " ";
            }
            Settings.Default.settingsCB = saveSettings;

            Settings.Default.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            SaveSettings();
        }

        private void buttonMP_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 5; i < tempCBox.Length; i++)
                {
                    if (tempCBox[i].SelectedIndex == -1)
                    {
                        MessageBox.Show("У вас есть не заполненные ячейки в факторах", "Ошибка расчетов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 1 - Факторы продукта
                // 2 - Факторы платформы
                // 3 - Факторы персонала
                // 4 - Факторы проекта
                double koefMP = CostFactors.RELY[RELY_CB.SelectedIndex] * CostFactors.DATA[DATA_CB.SelectedIndex] * CostFactors.CPLX[CPLX_CB.SelectedIndex] * CostFactors.RUSE[RUSE_CB.SelectedIndex] * CostFactors.DOCU[DOCU_CB.SelectedIndex]
                    * CostFactors.TIME[TIME_CB.SelectedIndex] * CostFactors.STOR[STOR_CB.SelectedIndex] * CostFactors.PVOL[PVOL_CB.SelectedIndex]
                    * CostFactors.ACAP[ACAP_CB.SelectedIndex] * CostFactors.PCAP[PCAP_CB.SelectedIndex] * CostFactors.PCON[PCON_CB.SelectedIndex] * CostFactors.AEXP[AEXP_CB.SelectedIndex] * CostFactors.PEXP[PEXP_CB.SelectedIndex] * CostFactors.LTEX[LTEX_CB.SelectedIndex]
                    * CostFactors.TOOL[TOOL_CB.SelectedIndex] * CostFactors.SITE[SITE_CB.SelectedIndex] * CostFactors.SCED[SCED_CB.SelectedIndex];

                MPLabel.Text = koefMP.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вводите корректные значения в поля!\n" + ex.Message, "Ошибка расчетов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button_CalcBClick(object sender, EventArgs e)
        {
            try
            {
                ComboBox[] assessmentFactors = { predictability_CB, devFlexibility_CB, permissionRisk_CB, Connectivity_CB, maturity_CB };

                foreach (var item in assessmentFactors)
                {
                    if (item.SelectedIndex == -1)
                    {
                        MessageBox.Show("У вас есть не заполненные ячейки в оценке масштабных факторов", "Ошибка расчетов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                CalcB_TextLabel.Text = (1.01 + (Convert.ToDouble(assessmentFactors[0].Text) + Convert.ToDouble(assessmentFactors[1].Text) + Convert.ToDouble(assessmentFactors[2].Text) +
                    Convert.ToDouble(assessmentFactors[3].Text) + Convert.ToDouble(assessmentFactors[4].Text)) / 100).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вводите корректные значения в поля!\n" + ex.Message, "Ошибка расчетов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_AutoCalcClick(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(ATPROD_TB.Text) == 0)
                {
                    AUTO_DEDUCTIONS.Text = "0";
                }
                AUTO_DEDUCTIONS.Text = ((Convert.ToDouble(KARLOS_TB.Text) * (Convert.ToDouble(AT_TB.Text) / 100.0) / Convert.ToDouble(ATPROD_TB.Text))).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вводите корректные значения в поля!\n" + ex.Message, "Ошибка расчетов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_resultCostClick(object sender, EventArgs e)
        {
            try
            {
                if (CalcB_TextLabel.Text == "")
                {
                    MessageBox.Show("Не рассчитан B", "Ошибка расчетов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MPLabel.Text == "")
                {
                    MessageBox.Show("Не рассчитан MP", "Ошибка расчетов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (AUTO_DEDUCTIONS.Text == "")
                {
                    MessageBox.Show("Не рассчитан ЗАТРАТЫ (КОЭФФИЦЕНТЫ)", "Ошибка расчетов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (betProg.Text == "")
                {
                    MessageBox.Show("Не указана ставка программиста", "Ошибка расчетов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double K = 1 + (Convert.ToDouble(BRAK_TB.Text) / 100.0);
                double linesCode = Convert.ToDouble(newLineCode.Text) + Convert.ToDouble(repeatLineCode.Text);

                double resultCost = (Convert.ToDouble(coefA_TB.Text)
                    * K
                    * Math.Pow(linesCode, Convert.ToDouble(CalcB_TextLabel.Text))
                    * Convert.ToDouble(MPLabel.Text)
                    + Convert.ToDouble(AUTO_DEDUCTIONS.Text)) * Convert.ToDouble(betProg.Text);

                textBox_resultCost.Text = Math.Round(resultCost, 2).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Вводите корректные значения в поля!\n" + ex.Message, "Ошибка расчетов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}