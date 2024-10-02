using thing_storage;

namespace Helpers
{
    public class Def_values
    {
        public static float get_sanity_value(CreatureTemplate crit)
        {
            //Constants variables CAN'T BE CHANGED.
            const float def = 0.0005f;  //Default Svalue.
            const float friendly_regen = 0.0035f;   //Sanity change may be positive or negative

            if (crit == null)
            {
                return def;
            }

            //....i think i already defined
            var crit_type = crit.type;                  //type
            var crit_ancestor = crit.ancestor;     //ancestors
            float value;                                //Svalue

            ///_______________________________________________________
            ///             MedalType
            ///_______________________________________________________

            //check the crit_type
            if (dict_storage.crit_dict.TryGetValue(crit_type, out value))
            {
                return value;
            }

            //check the List
            if (list_storage.friendly_creature_types.Contains(crit_type))
            {
                return -friendly_regen; //creature restores sanity of _player when it is nearby
            }

            ///_______________________________________________________
            ///             Ancestor
            ///_______________________________________________________


            if (crit_ancestor != null && crit_ancestor.type != null)      //if ancestor its NOT null
            {
                //check the ancestor
                if (dict_storage.crit_dict.TryGetValue(crit_ancestor.type, out value))
                {
                    return value;
                }
                if (list_storage.friendly_creature_types.Contains(crit_ancestor.type))
                {
                    return -friendly_regen; //creature restores sanity of _player when it is nearby
                }
            }

            return def;
        }
    }
}