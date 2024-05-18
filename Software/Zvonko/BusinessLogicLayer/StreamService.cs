using NAudio.Wave;
using System;

namespace BusinessLogicLayer {
    public class StreamService : IDisposable {
        private WaveIn recorder;
        private BufferedWaveProvider bufferedWaveProvider;
        private WaveOut player;

        public void OnStartStreaming() {
            InitializeRecorder();
            InitializePlayer();

            player.Play();
            recorder.StartRecording();
        }

        private void InitializeRecorder() {
            recorder = new WaveIn
            {
                WaveFormat = new WaveFormat(4800, 1),
                BufferMilliseconds = 100
            };
            recorder.DataAvailable += RecorderOnDataAvailable;
            bufferedWaveProvider = new BufferedWaveProvider(recorder.WaveFormat)
            {
                BufferDuration = TimeSpan.FromSeconds(5)
            };
        }

        private void InitializePlayer() {
            player = new WaveOut();
            player.Init(bufferedWaveProvider);
        }

        private void RecorderOnDataAvailable(object sender, WaveInEventArgs waveInEventArgs) {
            if (bufferedWaveProvider != null) {
                bufferedWaveProvider.AddSamples(waveInEventArgs.Buffer, 0, waveInEventArgs.BytesRecorded);
            }
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



