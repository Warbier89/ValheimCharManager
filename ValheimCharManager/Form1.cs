using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValheimCharManager
{
    public partial class fr_main : Form
    {
        public fr_main()
        {
            InitializeComponent();
            LoadCharactersIntoComboBox();
        }

        private void LoadCharactersIntoComboBox()
        {
            // Pfadkonstruktion wie zuvor
            string localLowPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"..\LocalLow");
            string finalValheimCharPath = Path.Combine(localLowPath, @"IronGate\Valheim\characters_local\");

            if (Directory.Exists(finalValheimCharPath))
            {
                // Alle Dateien im Ordner auslesen
                string[] characterFiles = Directory.GetFiles(finalValheimCharPath);

                cb_mainChar.Items.Clear();

                foreach (string filePath in characterFiles)
                {
                    // 1. Prüfen, ob die Dateiendung ".fch" ist
                    if (Path.GetExtension(filePath).Equals(".fch", StringComparison.OrdinalIgnoreCase))
                    {
                        // Nur den Dateinamen (ohne Pfad) und ohne Dateierweiterung holen
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

                        // 2. Prüfen, ob der Dateiname keinen Unterstrich "_" enthält
                        if (!fileNameWithoutExtension.Contains("_"))
                        {
                            cb_mainChar.Items.Add(fileNameWithoutExtension);
                        }
                    }
                }

                if (cb_mainChar.Items.Count > 0)
                {
                    cb_mainChar.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Keine passenden Charakterdateien (.fch ohne Unterstrich) im Ordner gefunden.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cb_mainChar.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show($"Der Valheim Charakter-Ordner wurde nicht gefunden:\n{finalValheimCharPath}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_mainChar.Enabled = false;
            }
        }
    }
}
