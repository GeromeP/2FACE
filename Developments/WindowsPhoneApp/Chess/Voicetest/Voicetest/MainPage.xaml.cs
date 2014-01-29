using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Voicetest.Resources;
using Windows.Phone.Speech.Recognition;

namespace Voicetest
{
    public partial class MainPage : PhoneApplicationPage
    {
        SpeechRecognizer recognizer;
        Dictionary<string, Piece> pieceList;

        // Constructeur
        public MainPage()
        {
            InitializeComponent();
            InitializeDictonnary();
            InitializeRecognizer();
        }

        private void InitializeDictonnary()
        {
            pieceList = new Dictionary<string,Piece>();
            pieceList.Add("tour", new Piece());
        }

        private void InitializeRecognizer()
        {
            Uri pieceList = new Uri("ms-appx:///Pieces.grxml");
            recognizer = new SpeechRecognizer();
            recognizer.Grammars.AddGrammarFromUri("string", pieceList);
            recognizer.Settings.EndSilenceTimeout = TimeSpan.FromSeconds(1.2);
        }

        private async void MicButton_Click(object sender, EventArgs e)
        {
            try
            {
                var recoResult = await recognizer.RecognizeAsync();

                if (recoResult.TextConfidence == SpeechRecognitionConfidence.High ||
                    recoResult.TextConfidence == SpeechRecognitionConfidence.Medium)
                {
                    string txtResult = "";

                    if (recoResult.Semantics.ContainsKey("piece") && recoResult.Semantics["piece"].Value.ToString() != "...")
                    {
                        txtResult = recoResult.Semantics["piece"].Value.ToString();
                    }
                    else if (recoResult.Semantics.ContainsKey("piece") && recoResult.Semantics["piece"].Value.ToString() == "...")
                    {
                        txtResult = "piece non trouvée";
                    }
                }
            }
            catch (System.Threading.Tasks.TaskCanceledException)
            {

            }catch(Exception err){
                const int privacyPolicyHResult = unchecked((int)0x80045509);

                if (err.HResult == privacyPolicyHResult)
                    MessageBox.Show("To run this sample, you must first accept the speech privacy policy. To do so, navigate to Settings -> speech on your phone and check 'Enable Speech Recognition Service' ");
                else
                    MessageBox.Show(String.Format("An error occurred: {0}", err.Message));   
            }
        }
    }
}