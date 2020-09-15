using System;
using System.Threading.Tasks;
using OBS.WebSocket.NET;

namespace SlidesToOBS
{

    public class ObsLocal : IDisposable
    {
        private bool _DisposedValue;
        private ObsWebSocket _OBS;

        public ObsLocal() { }

        public Task Connect()
        {
            _OBS = new ObsWebSocket();
            _OBS.Connect($"ws://127.0.0.1:4444", "");
            return Task.CompletedTask;
        }
	
        public bool ChangeScene(string scene)
        {
            _OBS.Api.SetCurrentScene(scene);
            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                _OBS.Disconnect();
                _OBS = null;
                _DisposedValue = true;
            }
        }

        ~ObsLocal()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}