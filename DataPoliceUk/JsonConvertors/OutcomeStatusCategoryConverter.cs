using DataPoliceUk.Enums;
using Newtonsoft.Json;
using System;

namespace DataPoliceUk.JsonConvertors
{
    internal class OutcomeStatusCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OutcomeStatusCategory) || t == typeof(OutcomeStatusCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Action to be taken by another organisation":
                    return OutcomeStatusCategory.ActionToBeTakenByAnotherOrganisation;
                case "Awaiting court outcome":
                    return OutcomeStatusCategory.AwaitingCourtOutcome;
                case "Court case unable to proceed":
                    return OutcomeStatusCategory.CourtCaseUnableToProceed;
                case "Court result unavailable":
                    return OutcomeStatusCategory.CourtResultUnavailable;
                case "Defendant found not guilty":
                    return OutcomeStatusCategory.DefendantFoundNotGuilty;
                case "Defendant sent to Crown Court":
                    return OutcomeStatusCategory.DefendantSentToCrownCourt;
                case "Formal action is not in the public interest":
                    return OutcomeStatusCategory.FormalActionIsNotInThePublicInterest;
                case "Investigation complete; no suspect identified":
                    return OutcomeStatusCategory.InvestigationCompleteNoSuspectIdentified;
                case "Local resolution":
                    return OutcomeStatusCategory.LocalResolution;
                case "Offender deprived of property":
                    return OutcomeStatusCategory.OffenderDeprivedOfProperty;
                case "Offender fined":
                    return OutcomeStatusCategory.OffenderFined;
                case "Offender given a caution":
                    return OutcomeStatusCategory.OffenderGivenACaution;
                case "Offender given community sentence":
                    return OutcomeStatusCategory.OffenderGivenCommunitySentence;
                case "Offender given conditional discharge":
                    return OutcomeStatusCategory.OffenderGivenConditionalDischarge;
                case "Offender given suspended prison sentence":
                    return OutcomeStatusCategory.OffenderGivenSuspendedPrisonSentence;
                case "Offender ordered to pay compensation":
                    return OutcomeStatusCategory.OffenderOrderedToPayCompensation;
                case "Offender otherwise dealt with":
                    return OutcomeStatusCategory.OffenderOtherwiseDealtWith;
                case "Offender sent to prison":
                    return OutcomeStatusCategory.OffenderSentToPrison;
                case "Status update unavailable":
                    return OutcomeStatusCategory.StatusUpdateUnavailable;
                case "Suspect charged as part of another case":
                    return OutcomeStatusCategory.SuspectChargedAsPartOfAnotherCase;
                case "Unable to prosecute suspect":
                    return OutcomeStatusCategory.UnableToProsecuteSuspect;
            }
            throw new Exception("Cannot unmarshal type OutcomeStatusCategory");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OutcomeStatusCategory)untypedValue;
            switch (value)
            {
                case OutcomeStatusCategory.ActionToBeTakenByAnotherOrganisation:
                    serializer.Serialize(writer, "Action to be taken by another organisation");
                    return;
                case OutcomeStatusCategory.AwaitingCourtOutcome:
                    serializer.Serialize(writer, "Awaiting court outcome");
                    return;
                case OutcomeStatusCategory.CourtCaseUnableToProceed:
                    serializer.Serialize(writer, "Court case unable to proceed");
                    return;
                case OutcomeStatusCategory.CourtResultUnavailable:
                    serializer.Serialize(writer, "Court result unavailable");
                    return;
                case OutcomeStatusCategory.DefendantFoundNotGuilty:
                    serializer.Serialize(writer, "Defendant found not guilty");
                    return;
                case OutcomeStatusCategory.DefendantSentToCrownCourt:
                    serializer.Serialize(writer, "Defendant sent to Crown Court");
                    return;
                case OutcomeStatusCategory.FormalActionIsNotInThePublicInterest:
                    serializer.Serialize(writer, "Formal action is not in the public interest");
                    return;
                case OutcomeStatusCategory.InvestigationCompleteNoSuspectIdentified:
                    serializer.Serialize(writer, "Investigation complete; no suspect identified");
                    return;
                case OutcomeStatusCategory.LocalResolution:
                    serializer.Serialize(writer, "Local resolution");
                    return;
                case OutcomeStatusCategory.OffenderDeprivedOfProperty:
                    serializer.Serialize(writer, "Offender deprived of property");
                    return;
                case OutcomeStatusCategory.OffenderFined:
                    serializer.Serialize(writer, "Offender fined");
                    return;
                case OutcomeStatusCategory.OffenderGivenACaution:
                    serializer.Serialize(writer, "Offender given a caution");
                    return;
                case OutcomeStatusCategory.OffenderGivenCommunitySentence:
                    serializer.Serialize(writer, "Offender given community sentence");
                    return;
                case OutcomeStatusCategory.OffenderGivenConditionalDischarge:
                    serializer.Serialize(writer, "Offender given conditional discharge");
                    return;
                case OutcomeStatusCategory.OffenderGivenSuspendedPrisonSentence:
                    serializer.Serialize(writer, "Offender given suspended prison sentence");
                    return;
                case OutcomeStatusCategory.OffenderOrderedToPayCompensation:
                    serializer.Serialize(writer, "Offender ordered to pay compensation");
                    return;
                case OutcomeStatusCategory.OffenderOtherwiseDealtWith:
                    serializer.Serialize(writer, "Offender otherwise dealt with");
                    return;
                case OutcomeStatusCategory.OffenderSentToPrison:
                    serializer.Serialize(writer, "Offender sent to prison");
                    return;
                case OutcomeStatusCategory.StatusUpdateUnavailable:
                    serializer.Serialize(writer, "Status update unavailable");
                    return;
                case OutcomeStatusCategory.SuspectChargedAsPartOfAnotherCase:
                    serializer.Serialize(writer, "Suspect charged as part of another case");
                    return;
                case OutcomeStatusCategory.UnableToProsecuteSuspect:
                    serializer.Serialize(writer, "Unable to prosecute suspect");
                    return;
            }
            throw new Exception("Cannot marshal type OutcomeStatusCategory");
        }

        public static readonly OutcomeStatusCategoryConverter Singleton = new OutcomeStatusCategoryConverter();
    }
}
