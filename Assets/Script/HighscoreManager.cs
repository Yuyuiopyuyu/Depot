using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using UnityEditor;

public class HighscoreManager : MonoBehaviour {
    private string key = "ilovecatandcookies";

    void Start () {
        // Check if highscore file is initialized
        int result;
        string highscore = File.ReadAllText(Application.dataPath + "/Resources/highscore.txt");
        // If we can't parse the file, it was corrupted or not already initialized
        if (!int.TryParse(EncryptOrDecrypt(highscore, this.key), out result)) {
            File.WriteAllText(Application.dataPath + "/Resources/highscore.txt", EncryptOrDecrypt("0", this.key));
        }
    }

    public int getHighscore() {
        // Read highscore file content
        string highscore = File.ReadAllText(Application.dataPath + "/Resources/highscore.txt");
        // Decrypt and return it
        return int.Parse(EncryptOrDecrypt(highscore, this.key));
    }

    public bool setHighscore(int score) {
        int previousScore = getHighscore();

        // Check if we have a new highscore
        if(previousScore < score) {
            // Encrypt the new score
            string newScore = EncryptOrDecrypt(score.ToString(), this.key);
            // Write it to the file
            File.WriteAllText(Application.dataPath + "/Resources/highscore.txt", newScore);
            return true;
        } else {
            return false;
        }
    }
	
    string EncryptOrDecrypt(string text, string key) {
        var result = new StringBuilder();

        for (int c = 0; c < text.Length; c++)
            result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));

        return result.ToString();
    }
}
