namespace FirstApp
{
    class VideoManager
    {
        private IVideoComand Comand;
        internal async Task DownloadVideo()
        {
            await Comand.Download();
        }

        internal async Task ShowVideoInfo()
        {
            await Comand.ShowInfo();
        }

        internal void SetComand (IVideoComand Comand)
        {
            this.Comand = Comand;
        }
    }
}


