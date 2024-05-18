using NAudio.Wave;

namespace BusinessLogicLayer {
    public class StreamService {
        private static WaveIn recorder;
        private static BufferedWaveProvider bufferedWaveProvider;
        private static WaveOut player;

        public static void OnStartStreaming() {
            recorder = new WaveIn();
            recorder.DataAvailable += RecorderOnDataAvailable;

            bufferedWaveProvider = new BufferedWaveProvider(recorder.WaveFormat);

            player = new WaveOut();
            player.Init(bufferedWaveProvider);

            player.Play();
            recorder.StartRecording();
        }

        private static void RecorderOnDataAvailable(object sender, WaveInEventArgs waveInEventArgs) {
            if (bufferedWaveProvider != null) {
                bufferedWaveProvider.AddSamples(waveInEventArgs.Buffer, 0, waveInEventArgs.BytesRecorded);
            }
        }

        public static void OnStopStreaming() {
            if (recorder != null) {
                recorder.StopRecording();
            }
            if (player != null) {
                player.Stop();
            }
        }
    }
}
