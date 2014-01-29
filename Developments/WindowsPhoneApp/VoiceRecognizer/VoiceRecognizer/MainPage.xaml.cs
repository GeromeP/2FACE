using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using VoiceRecognizer.Resources;
using Windows.Phone.Speech;
using Windows.Phone.Speech.Synthesis;
using Windows.Phone.Speech.Recognition;
using Windows.Foundation;

namespace VoiceRecognizer
{
    public partial class MainPage : PhoneApplicationPage
    {
        SpeechSynthesizer synthetizer;
        SpeechRecognizer recognizer;

        IAsyncOperation<SpeechRecognitionResult> recoOperation;

        bool inProgress = false;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(synthetizer == null)
                synthetizer = new SpeechSynthesizer();

            if (recognizer == null)
            {
                Uri rule = new Uri("ms-appx:///CitiesList.xml", UriKind.RelativeOrAbsolute);
                recognizer = new SpeechRecognizer();
                recognizer.Grammars.AddGrammarFromUri("positionList", rule);
            }

            base.OnNavigatedTo(e);
        }

        private async void ear(object sender, RoutedEventArgs e)
        {
            if (inProgress)
            {
                inProgress = false;
                btnLire.Content = "Commencer la reconnaissance vocale";
                txtResult.Text = String.Empty;

                if (recoOperation != null && recoOperation.Status == AsyncStatus.Started)
                    recoOperation.Cancel();
                return;
            }
            else
            {
                inProgress = true;
                btnLire.Content = "Reconnaissance vocal en écoute";
            }

            while (inProgress)
            {
                try
                {
                    recoOperation = recognizer.RecognizeAsync();
                    var recoResult = await recoOperation;

                    if (recoResult.TextConfidence < SpeechRecognitionConfidence.Medium)
                    {
                        txtResult.Text = "Je n'ai pas compris ";
                        await synthetizer.SpeakTextAsync(txtResult.Text);
                    }
                    else
                    {
                        txtResult.Text = "position : " + recoResult.Text;
                        await synthetizer.SpeakTextAsync(txtResult.Text);
                    }
                }
                catch(System.Threading.Tasks.TaskCanceledException){}
                catch(Exception err)
                {
                    const int privacyPolicyHResult = unchecked((int)0x80045509);

                    if (err.HResult == privacyPolicyHResult)
                    {
                        MessageBox.Show("To run this sample, you must first accept the speech privacy policy. To do so, navigate to Settings -> speech on your phone and check 'Enable Speech Recognition Service' ");
                        inProgress = false;
                        btnLire.Content = "Commencer la reconnaissance vocale";
                    }
                    else
                    {
                        txtResult.Text = "Error: " + err.Message;
                    }
                }
            }
        }
    }
}