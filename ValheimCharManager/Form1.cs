using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValheimCharManager.Properties;

namespace ValheimCharManager
{
    public partial class fr_main : Form
    {

        private string valheimCharFolderPath;// Basis-Pfad
        private string valheimBuildsFolderPath; // Pfad zum "builds" Unterordner

        public fr_main()
        {
            InitializeComponent();

            // Pfadkonstruktion einmalig beim Start der Form
            string localLowPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"..\LocalLow");
            valheimCharFolderPath = Path.Combine(localLowPath, @"IronGate\Valheim\characters_local\");
            valheimBuildsFolderPath = Path.Combine(valheimCharFolderPath, "builds"); // Pfad zum Builds-Unterordner zusammensetzen

            LoadCharactersIntoMainComboBox(); // Diese Methode füllt cb_mainChar
            UpdateBuildNameTextBox();     // Sofortige Befüllung der TextBox beim Start
            LoadBuildsIntoBuildComboBox();
        }

        private void LoadCharactersIntoMainComboBox()
        {
            if (Directory.Exists(valheimCharFolderPath))
            {
                string[] characterFiles = Directory.GetFiles(valheimCharFolderPath);

                cb_mainChar.Items.Clear();

                foreach (string filePath in characterFiles)
                {
                    if (Path.GetExtension(filePath).Equals(".fch", StringComparison.OrdinalIgnoreCase))
                    {
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

                        // Bedingung: KEIN Unterstrich "_"
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
                    MessageBox.Show("No matching main character files (.fch without underscore) found in the folder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cb_mainChar.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show($"The Valheim character folder was not found:\n{valheimCharFolderPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_mainChar.Enabled = false;
                cb_chosseBuild.Enabled = false; // Auch die zweite ComboBox deaktivieren
            }
        }

        private void LoadBuildsIntoBuildComboBox()
        {
            // Zuerst prüfen, ob der builds-Ordner existiert
            if (!Directory.Exists(valheimBuildsFolderPath)) // Wichtig: !Directory.Exists
            {
                // Der Ordner existiert nicht, Frage den Benutzer
                DialogResult result = MessageBox.Show(
                    $"The folder ‘builds’ does not seem to exist yet ({valheimBuildsFolderPath}).\nDo you want to create this?",
                    "Create folder?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(valheimBuildsFolderPath);
                        MessageBox.Show($"The Folder '{valheimBuildsFolderPath}' was successfully created.", "Folder created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Nach dem Erstellen kann die ComboBox trotzdem noch leer sein,
                        // aber der Ordner ist jetzt da für zukünftige Builds.
                        cb_chosseBuild.Enabled = true; // Sicherstellen, dass sie wieder aktiv ist
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error when creating the folder '{valheimBuildsFolderPath}':\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cb_chosseBuild.Enabled = false; // Bei Fehler deaktivieren
                        return; // Methode beenden
                    }
                }
                else
                {
                    // Benutzer möchte den Ordner nicht erstellen
                    MessageBox.Show("The ‘builds’ folder was not created. Builds cannot be loaded or saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cb_chosseBuild.Enabled = false; // ComboBox deaktivieren
                    return; // Methode beenden
                }
            }

            // Wenn der Ordner existiert (oder gerade erstellt wurde), den Inhalt laden
            string[] buildFiles = Directory.GetFiles(valheimBuildsFolderPath);

            cb_chosseBuild.Items.Clear();

            foreach (string filePath in buildFiles)
            {
                if (Path.GetExtension(filePath).Equals(".fch", StringComparison.OrdinalIgnoreCase))
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

                    if (fileNameWithoutExtension.Contains("_"))
                    {
                        cb_chosseBuild.Items.Add(fileNameWithoutExtension);
                    }
                }
            }

            if (cb_chosseBuild.Items.Count > 0)
            {
                cb_chosseBuild.SelectedIndex = 0;
            }
            else
            {
                // Diese Meldung erscheint nur, wenn der Ordner existiert, aber keine passenden Dateien enthält.
                // Nicht, wenn der Ordner nicht existierte und der Benutzer ihn nicht erstellen wollte.
                MessageBox.Show("No matching build character files (.fch with underscore) found in the ‘builds’ folder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cb_chosseBuild.Enabled = false;
            }
        }

        private void bt_switchBuild_Click(object sender, EventArgs e)
        {
            // 1. Validierung: Prüfen, ob in beiden ComboBoxen etwas ausgewählt ist
            if (cb_mainChar.SelectedItem == null)
            {
                MessageBox.Show("Please select a main character from the list above.", "Lack of choice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cb_chosseBuild.SelectedItem == null)
            {
                MessageBox.Show("Please select a build character from the list below.", "Lack of choice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Dateinamen abrufen (OHNE ENDUNG, da sie noch angehängt wird)
            string mainCharNameWithoutExtension = cb_mainChar.SelectedItem.ToString();
            string buildCharNameWithoutExtension = cb_chosseBuild.SelectedItem.ToString();

            // 3. Vollständige Pfade erstellen (MIT ENDUNG)
            string mainCharFilePath = Path.Combine(valheimCharFolderPath, mainCharNameWithoutExtension + ".fch");
            string buildCharSourcePath = Path.Combine(valheimBuildsFolderPath, buildCharNameWithoutExtension + ".fch");
            string buildCharTargetPath = Path.Combine(valheimCharFolderPath, mainCharNameWithoutExtension + ".fch");

            // Überprüfung, ob die Quelldateien existieren (sehr wichtig!)
            if (!File.Exists(mainCharFilePath))
            {
                MessageBox.Show($"The main character file '{mainCharNameWithoutExtension}.fch' was not found. Operation canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(buildCharSourcePath))
            {
                MessageBox.Show($"The build file '{buildCharNameWithoutExtension}.fch' was not found. Operation canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 5. Hauptcharakterdatei löschen
                if (File.Exists(mainCharFilePath))
                {
                    File.Delete(mainCharFilePath);
                }

                // 6. Build-Charakter kopieren und umbenennen
                File.Copy(buildCharSourcePath, buildCharTargetPath, true);

                MessageBox.Show($"The Build '{buildCharNameWithoutExtension}.fch' was successfully activated as '{mainCharNameWithoutExtension}.fch'!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred when changing the build:\n{ex.Message}\n\nPlease check the permissions for the folders.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 7. ComboBoxen aktualisieren
                LoadCharactersIntoMainComboBox();
                LoadBuildsIntoBuildComboBox();
            }
        }

        private void cb_mainChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBuildNameTextBox(); // Rufe eine Hilfsmethode auf
        }

        //Hilfsmethode zum Aktualisieren der TextBox
        private void UpdateBuildNameTextBox()
        {
            if (cb_mainChar.SelectedItem != null)
            {
                string mainCharNameWithoutExtension = cb_mainChar.SelectedItem.ToString();
                tb_buildName.Text = mainCharNameWithoutExtension + "_";

                // Optional: Cursor ans Ende der vorgeschriebenen Zeichen setzen
                tb_buildName.SelectionStart = tb_buildName.Text.Length;
                tb_buildName.SelectionLength = 0;
                tb_buildName.Focus(); // Fokus auf die Textbox legen
            }
            else
            {
                tb_buildName.Clear(); // Textbox leeren, wenn nichts ausgewählt ist
            }
        }

        // Event-Handler für den "Build speichern" Button
        private void bt_saveBuild_Click(object sender, EventArgs e)
        {
            // 1. Validierung: Hauptcharakter ausgewählt?
            if (cb_mainChar.SelectedItem == null)
            {
                MessageBox.Show("Please select a main character in the list above whose build you would like to save.", "Lack of choice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validierung: Build-Name in der Textbox vorhanden und gültig?
            string newBuildNameWithoutExtension = tb_buildName.Text.Trim(); // .Trim() entfernt Leerzeichen am Anfang/Ende

            if (string.IsNullOrWhiteSpace(newBuildNameWithoutExtension))
            {
                MessageBox.Show("Please enter a name for the new build.", "Missing input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Zusätzliche Validierung für gültige Dateinamen (keine ungültigen Zeichen)
            char[] invalidChars = Path.GetInvalidFileNameChars();
            if (newBuildNameWithoutExtension.Any(c => invalidChars.Contains(c)))
            {
                MessageBox.Show($"The build name contains invalid characters. Please do not use any of the following characters: {string.Join("", invalidChars)}", "Invalid file name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Pfade festlegen
            string mainCharNameWithoutExtension = cb_mainChar.SelectedItem.ToString();
            string sourceFilePath = Path.Combine(valheimCharFolderPath, mainCharNameWithoutExtension + ".fch"); // Die zu kopierende Datei

            // Der Zielpfad für den neuen Build
            string destinationFilePath = Path.Combine(valheimBuildsFolderPath, newBuildNameWithoutExtension + ".fch");

            // 4. Prüfen, ob die Quelldatei existiert
            if (!File.Exists(sourceFilePath))
            {
                MessageBox.Show($"The main character file '{mainCharNameWithoutExtension}.fch' was not found in the main directory. Save canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5. Prüfen, ob der Build-Ordner existiert (und ggf. vorher anbieten zu erstellen)
            // Die LoadBuildsIntoBuildComboBox() kümmert sich schon darum, den Ordner anzulegen.
            // Hier prüfen wir nur, ob er tatsächlich da ist, bevor wir versuchen zu speichern.
            if (!Directory.Exists(valheimBuildsFolderPath))
            {
                MessageBox.Show("The ‘builds’ folder does not exist. Please create it first (e.g. by restarting the application and confirming the prompt).", "Folder missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 6. Bestätigung, falls der Build-Name bereits existiert (Überschreibungsschutz)
            if (File.Exists(destinationFilePath))
            {
                DialogResult overwriteResult = MessageBox.Show(
                    $"The build with the name '{newBuildNameWithoutExtension}.fch' already exists in the ‘builds’ folder.\nWould you like to overwrite it?",
                    "Overwrite build?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (overwriteResult == DialogResult.No)
                {
                    MessageBox.Show("Save canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // 7. Datei kopieren
            try
            {
                // File.Copy(Quelle, Ziel, überschreiben?)
                File.Copy(sourceFilePath, destinationFilePath, true); // true = Überschreiben erlauben

                MessageBox.Show($"The Build '{newBuildNameWithoutExtension}.fch' was successfully saved in the ‘builds’ folder!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred when saving the build:\n{ex.Message}\n\nPlease check the permissions for the folders.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 8. Build-ComboBox aktualisieren, damit der neue Build sofort sichtbar ist
                LoadBuildsIntoBuildComboBox();
            }
        }

        private void pb_folder_DoubleClick(object sender, EventArgs e)
        {
            // Prüfen, ob der Hauptordner überhaupt existiert
            if (Directory.Exists(valheimCharFolderPath))
            {
                try
                {
                    // Öffne den Ordner im Explorer
                    // Process.Start nimmt einen Pfad entgegen und öffnet ihn mit dem Standardprogramm,
                    // das für diesen Dateityp (in diesem Fall ein Ordner) registriert ist, also dem Explorer.
                    Process.Start(valheimCharFolderPath);
                }
                catch (Exception ex)
                {
                    // Fehlerbehandlung, falls das Öffnen fehlschlägt (z.B. keine Berechtigungen)
                    MessageBox.Show($"Error when opening the folder:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Informieren, falls der Ordner nicht gefunden wurde
                MessageBox.Show($"The specified folder was not found:\n{valheimCharFolderPath}", "Folder not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void pb_folder_MouseHover(object sender, EventArgs e)
        {
            pb_folder.Cursor = Cursors.Hand;
        }

        private void pb_folder_MouseLeave_1(object sender, EventArgs e)
        {
            pb_folder.Cursor = Cursors.Default;
        }
    }
}
