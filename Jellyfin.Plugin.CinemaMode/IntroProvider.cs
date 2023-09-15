using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jellyfin.Data.Entities;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;

namespace Jellyfin.Plugin.CinemaMode
{
    public class IntroProvider : IIntroProvider
    {
        public string Name { get; } = "CinemaMode";

        public Task<IEnumerable<IntroInfo>> GetIntros(BaseItem item, User user)
        {

            
            IntroManager introManager = new IntroManager();
            return Task.FromResult(introManager.Get(item, user));
        }

        public IEnumerable<string> GetAllIntroFiles()
        {
            // not implemented
            return Enumerable.Empty<string>();
        }
    }
}
