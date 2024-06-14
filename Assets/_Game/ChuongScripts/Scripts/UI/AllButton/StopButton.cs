namespace ChuongCustom
{
    public class StopButton : AButton
    {
        protected override void OnClickButton()
        {
            Manager.InGame.Stop();
        }

        protected override void OnStart()
        {
        }
    }
}