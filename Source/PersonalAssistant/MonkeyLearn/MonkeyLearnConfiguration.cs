namespace PersonalAssistant.MonkeyLearn
{
    public class MonkeyLearnConfiguration
    {
        static MonkeyLearnConfiguration()
        {
        }

        public static MonkeyLearnConfiguration Current { get; set; } = new MonkeyLearnConfiguration();

        public string ApiKey => "55bdcb2bfdcea0410c10fbbd9aac659bcfa9eb52";
    }
}