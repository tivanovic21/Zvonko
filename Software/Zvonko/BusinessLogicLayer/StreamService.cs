using NAudio.Wave;
using System;

namespace BusinessLogicLayer {
    public class StreamService : IDisposable {
        private WaveIn recorder;
        private BufferedWaveProvider bufferedWaveProvider;
        private WaveOut player;
        private int delayInMilliseconds;

        public StreamService(TimeSpan delay) {
            delayInMilliseconds = (int)delay.TotalMilliseconds;
        }

        public void OnStartStreaming() {
            InitializeRecorder();
            InitializePlayer();

            player.Play();
            recorder.StartRecording();
        }

        private void InitializeRecorder() {
            recorder = new WaveIn {
                WaveFormat = new WaveFormat(48000, 1),
                BufferMilliseconds = 100
            };
            recorder.DataAvailable += RecorderOnDataAvailable;
            bufferedWaveProvider = new BufferedWaveProvider(recorder.WaveFormat) {
                BufferDuration = TimeSpan.FromSeconds(5)
            };
        }

        private void InitializePlayer() {
            player = new WaveOut();
            player.Init(bufferedWaveProvider);
        }

        private void RecorderOnDataAvailable(object sender, WaveInEventArgs waveInEventArgs) {
            byte[] buffer = waveInEventArgs.Buffer;
            int bytesRecorded = waveInEventArgs.BytesRecorded;

            if (bufferedWaveProvider.BufferedDuration.TotalMilliseconds < delayInMilliseconds) {
                byte[] silence = new byte[bytesRecorded];
                bufferedWaveProvider.AddSamples(silence, 0, silence.Length);
            }

            bufferedWaveProvider.AddSamples(buffer, 0, bytesRecorded);
        }

        public void OnStopStreaming() {
            if (recorder != null) {
                recorder.StopRecording();
                recorder.Dispose();
                recorder = null;
            }
            if (player != null) {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }

        public void Dispose() {
            OnStopStreaming();
        }
    }
}
