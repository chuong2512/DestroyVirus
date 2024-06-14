namespace ChuongCustom
{
    public class ContinutButton : AButton
    {
        protected override void OnClickButton()
        {
            Manager.InGame.ContinueGame();
        }

        protected override void OnStart()
        {
        }
    }
}