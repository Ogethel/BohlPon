using System;
using System.Runtime.Serialization;

namespace ALS.Patterns.COR
{
    public abstract class QuestMessageBase
    {
        public SerializableGUID QuestId;

        public class StartQuestMessage : QuestMessageBase
        {

        }

        public class CompleteQuestMessage : QuestMessageBase
        {
            
        }

        public class FailQuestMessage : QuestMessageBase
        {

        }
    }
}
