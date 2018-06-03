using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShTK.Audio
{
    public interface ISound : IDisposable
    {
        int Pan { get; set; }
        int Volume { get; set; }
        int Pitch { get; set; }
        int Tempo { get; set; }

        void Play();
        void Stop();
    }

    public class Sound : ISound
    {
        private int pan = 0; 

        /// <summary>
        /// A value from -10 to 10. Where -10 is far left and 10 is far right. 
        /// A pan value of 0 will achieve an exact balance on both sides.
        /// </summary>
        public int Pan
        {
            get
            {
                return pan;
            }
            set
            {
                if (value > 10)
                {
                    pan = 10;
                }
                else if (value < -10)
                {
                    pan = -10;
                }
                else
                {
                    pan = value;
                }
            }
        }

        /// <summary>
        /// 100 is maximum and 0 is mute. Keep in mind, muting audio doesn't mean it's disabled
        /// </summary>
        public int Volume
        {
            get
            {
                return pan;
            }
            set
            {
                if (value > 100)
                {
                    pan = 100;
                }
                else if (value < 0)
                {
                    pan = 0;
                }
                else
                {
                    pan = value;
                }
            }
        }

        /// <summary>
        /// Pitch
        /// </summary>
        public int Pitch { get; set; }

        /// <summary>
        /// Tempo
        /// </summary>
        public int Tempo { get; set; }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
