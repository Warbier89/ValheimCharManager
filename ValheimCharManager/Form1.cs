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

        private string valheimCharFolderPath;// Basis-Pfad
        private string valheimBuildsFolderPath; // Pfad zum "builds" Unterordner

        public fr_main()
        {
            InitializeComponent();

            // Pfadkonstruktion einmalig beim Start der Form
            string localLowPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"..\LocalLow");
            valheimCharFolderPath = Path.Combine(localLowPath, @"IronGate\Valheim\characters_local\");

            // NEU: Pfad zum Builds-Unterordner zusammensetzen
            valheimBuildsFolderPath = Path.Combine(valheimCharFolderPath, "builds");

            LoadCharactersIntoComboBox();
            LoadBuildsIntoBuildComboBox();
        }

        private void LoadCharactersIntoComboBox()
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
                    MessageBox.Show("Keine passenden Hauptcharakter-Dateien (.fch ohne Unterstrich) im Ordner gefunden.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cb_mainChar.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show($"Der Valheim Charakter-Ordner wurde nicht gefunden:\n{valheimCharFolderPath}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    $"Der Ordner 'builds' scheint noch nicht zu existieren ({valheimBuildsFolderPath}).\nWollen Sie diesen anlegen?",
                    "Ordner erstellen?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(valheimBuildsFolderPath);
                        MessageBox.Show($"Der Ordner '{valheimBuildsFolderPath}' wurde erfolgreich erstellt.", "Ordner erstellt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Nach dem Erstellen kann die ComboBox trotzdem noch leer sein,
                        // aber der Ordner ist jetzt da für zukünftige Builds.
                        cb_chosseBuild.Enabled = true; // Sicherstellen, dass sie wieder aktiv ist
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fehler beim Erstellen des Ordners '{valheimBuildsFolderPath}':\n{ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cb_chosseBuild.Enabled = false; // Bei Fehler deaktivieren
                        return; // Methode beenden
                    }
                }
                else
                {
                    // Benutzer möchte den Ordner nicht erstellen
                    MessageBox.Show("Der 'builds'-Ordner wurde nicht erstellt. Builds können nicht geladen oder gespeichert werden.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Keine passenden Build-Charakterdateien (.fch mit Unterstrich) im 'builds'-Ordner gefunden.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cb_chosseBuild.Enabled = false;
            }
        }

        private void bt_switchBuild_Click(object sender, EventArgs e)
        {
            // 1. Validierung: Prüfen, ob in beiden ComboBoxen etwas ausgewählt ist
            if (cb_mainChar.SelectedItem == null)
            {
                MessageBox.Show("Bitte wählen Sie einen Hauptcharakter in der oberen Liste aus.", "Fehlende Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Methode beenden
            }

            if (cb_chosseBuild.SelectedItem == null)
            {
                MessageBox.Show("Bitte wählen Sie einen Build-Charakter in der unteren Liste aus.", "Fehlende Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Methode beenden
            }

            // 2. Dateinamen abrufen (OHNE ENDUNG, da sie noch angehängt wird)
            string mainCharNameWithoutExtension = cb_mainChar.SelectedItem.ToString();
            string buildCharNameWithoutExtension = cb_chosseBuild.SelectedItem.ToString();

            // 3. Vollständige Pfade erstellen (MIT ENDUNG)
            // Die Endung ".fch" muss immer angehängt werden
            string mainCharFilePath = Path.Combine(valheimCharFolderPath, mainCharNameWithoutExtension + ".fch");
            string buildCharSourcePath = Path.Combine(valheimBuildsFolderPath, buildCharNameWithoutExtension + ".fch");

            // Das Ziel für die umbenannte Build-Datei ist der Hauptordner mit dem Namen des Hauptcharakters
            string buildCharTargetPath = Path.Combine(valheimCharFolderPath, mainCharNameWithoutExtension + ".fch");

            // Überprüfung, ob die Quelldateien existieren (sehr wichtig!)
            if (!File.Exists(mainCharFilePath))
            {
                MessageBox.Show($"Die Hauptcharakter-Datei '{mainCharNameWithoutExtension}.fch' wurde nicht gefunden. Operation abgebrochen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(buildCharSourcePath))
            {
                MessageBox.Show($"Die Build-Datei '{buildCharNameWithoutExtension}.fch' wurde nicht gefunden. Operation abgebrochen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Sicherung/Bestätigung vom Benutzer
            DialogResult confirmResult = MessageBox.Show(
                $"Möchten Sie wirklich den Hauptcharakter '{mainCharNameWithoutExtension}.fch' durch den Build '{buildCharNameWithoutExtension}.fch' ersetzen?\n\n" +
                "WARNUNG: Dies überschreibt Ihre aktuelle Charakterdatei unwiderruflich!",
                "Bestätigung",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Cancel)
            {
                MessageBox.Show("Vorgang abgebrochen.", "Abgebrochen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Methode beenden, wenn der Benutzer abbricht
            }

            try
            {
                // 5. Hauptcharakterdatei löschen
                // Es ist wichtig, die existierende Datei zu löschen, damit File.Copy nicht fehlschlägt,
                // wenn der Zielname bereits existiert und keine Überschreibung erlaubt ist (was wir nicht wollen, da wir sie explizit ersetzen).
                if (File.Exists(mainCharFilePath)) // Doppelte Prüfung schadet nicht
                {
                    File.Delete(mainCharFilePath);
                    // Optional: Meldung für Debugging
                    // MessageBox.Show($"Datei '{mainCharFilePath}' gelöscht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 6. Build-Charakter kopieren und umbenennen
                // File.Copy(Quelle, Ziel, überschreiben?)
                // Da wir das Ziel (mainCharFilePath) gerade gelöscht haben, brauchen wir "true" nicht unbedingt,
                // aber es ist gute Praxis, wenn man sich nicht 100% sicher ist, dass das Ziel nicht existiert.
                File.Copy(buildCharSourcePath, buildCharTargetPath, true); // true = Ziel überschreiben, falls es doch existiert

                MessageBox.Show($"Der Build '{buildCharNameWithoutExtension}.fch' wurde erfolgreich als '{mainCharNameWithoutExtension}.fch' aktiviert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ein Fehler ist beim Wechsel des Builds aufgetreten:\n{ex.Message}\n\nBitte prüfen Sie die Berechtigungen für die Ordner.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 7. ComboBoxen aktualisieren, egal ob erfolgreich oder nicht
                // Die Build-ComboBox muss nicht zwingend aktualisiert werden, da sich ihr Inhalt nicht ändert.
                // Aber die Main-Char-ComboBox könnte sich indirekt ändern, falls wir mal
                // auch Builds in den Main-Ordner kopieren würden, die keinen Unterstrich haben (was hier nicht der Fall ist).
                // Eine vollständige Aktualisierung ist am sichersten.
                LoadCharactersIntoComboBox();
                LoadBuildsIntoBuildComboBox();
            }
        }
    }
}
