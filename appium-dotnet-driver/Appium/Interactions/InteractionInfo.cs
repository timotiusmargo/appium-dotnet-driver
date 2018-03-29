//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//See the NOTICE file distributed with this work for additional
//information regarding copyright ownership.
//You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.

using System;
using System.Collections.Generic;

namespace OpenQA.Selenium.Appium.Interactions
{
    /// <summary>
    /// Provides a method by which optional attributes can be added to an Interactions.
    /// </summary>
    public interface IInteractionInfo
    {
        /// <summary>
        /// Returns optional values that are set to extend the default interaction values.
        /// </summary>
        /// <returns>A <see cref="Dictionary{TKey, TValue}"/> representing the values that are set.</returns>
        Dictionary<string, object> ToDictionary();
    }

    /// <summary>
    /// Represents a collection of optional attributes for pen pointer interaction.
    /// </summary>
    public class PenInfo : IInteractionInfo
    {
        /// <summary>
        /// Specifies pen buttons that can be pressed on pen interactions.
        /// </summary>
        [Flags]
        public enum PenButton
        {
            Uninitialized = -1,

            /// <summary>
            /// No button is pressed
            /// </summary>
            None = 0,

            /// <summary>
            /// The barrel/right click button
            /// </summary>
            Barrel = 2,

            /// <summary>
            /// The eraser/top button
            /// </summary>
            Eraser = 32
        }

        /// <summary>
        /// Gets or sets which pen button(s) that is/are pressed. E.g. PenButton.Barrel | PenButton.Eraser
        /// </summary>
        public PenButton PenButtons = PenButton.Uninitialized;

        /// <summary>
        /// Gets or sets the force exerted by the pen device
        /// </summary>
        public double? Pressure { get; set; }

        /// <summary>
        /// Gets or sets the clockwise rotation or twist of the pen device
        /// </summary>
        public double? Rotation { get; set; }

        /// <summary>
        /// Gets or sets the angle of tilt of the pen device along the x-axis
        /// </summary>
        public int? TiltX { get; set; }

        /// <summary>
        /// Gets or sets the angle of tilt of the pen device along the y-axis
        /// </summary>
        public int? TiltY { get; set; }

        /// <summary>
        /// Returns optional values that are set to extend the default pen pointer interaction values.
        /// </summary>
        /// <returns>A <see cref="Dictionary{TKey, TValue}"/> representing the values that are set.</returns>
        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> toReturn = new Dictionary<string, object>();

            if (PenButtons != PenButton.Uninitialized)
            {
                toReturn["buttons"] = PenButtons;
            }
            if (Pressure.HasValue)
            {
                toReturn["pressure"] = Pressure;
            }
            if (Rotation.HasValue)
            {
                toReturn["rotation"] = Rotation;
            }
            if (TiltX.HasValue)
            {
                toReturn["tiltX "] = TiltX;
            }
            if (TiltY.HasValue)
            {
                toReturn["tiltY "] = TiltY;
            }

            return toReturn;
        }
    }

    /// <summary>
    /// Represents a collection of optional attributes for touch pointer interaction.
    /// </summary>
    public class TouchInfo : IInteractionInfo
    {
        /// <summary>
        /// Gets or sets the force exerted by the touch contact on the surface
        /// </summary>
        public double? Pressure { get; set; }

        /// <summary>
        /// Gets or sets the counter-clockwise angle of rotation around the major axis of the pointer
        /// device (the z-axis, perpendicular to the surface of the digitizer).
        /// </summary>
        public int? Orientation { get; set; }

        /// <summary>
        /// Gets or sets the width of the bounding box centered in the touch contact area
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the bounding box centered in the touch contact area
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Returns optional values that are set to extend the default touch pointer interaction values.
        /// </summary>
        /// <returns>A <see cref="Dictionary{TKey, TValue}"/> representing the values that are set.</returns>
        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> toReturn = new Dictionary<string, object>();

            if (Pressure.HasValue)
            {
                toReturn["pressure"] = Pressure;
            }
            if (Orientation.HasValue)
            {
                toReturn["orientation"] = Orientation;
            }
            if (Width.HasValue)
            {
                toReturn["width "] = Width;
            }
            if (Height.HasValue)
            {
                toReturn["height "] = Height;
            }

            return toReturn;
        }
    }
}