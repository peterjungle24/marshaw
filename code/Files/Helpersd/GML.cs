using UnityEngine;

namespace Helpers
{
    public static class GML
    {
        /// <summary>
        /// while you holds the button
        /// </summary>
        /// <param name="key"></param>
        public static bool keyboard_check(KeyCode key)
        {
            return Input.GetKey(key);
        }
        /// <summary>
        /// while you press the button
        /// </summary>
        /// <param name="key"></param>
        public static bool keyboard_check_down(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }
        /// <summary>
        /// while you release the button
        /// </summary>
        /// <param name="key"></param>
        public static bool keyboard_check_up(KeyCode key)
        {
            return Input.GetKeyUp(key);
        }
    }
}
