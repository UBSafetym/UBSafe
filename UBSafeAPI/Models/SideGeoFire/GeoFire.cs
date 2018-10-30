﻿namespace UBSafeAPI.Models.SideGeoFire
{
    public static class GeoFire
    {

        /// <summary>
        /// Builds a firebase compatible GeoFire location entry
        /// </summary>
        /// <param name="latitude">latitude of location</param>
        /// <param name="longitude">longitude of location</param>
        /// <returns>Key stored in geofire</returns>
        public static string BuildGeoHash(double latitude, double longitude)
        {
            // Validate location
            ValidateLocation(latitude, longitude);

            // Generate a new geohash and return it
            return Geohash.Encode(latitude, longitude);
        }

        /// <summary>
        /// Validates the key to ensure it is not empty, does not contain more characters than 755
        /// UTF-8 encoded, cannot contain . $ # [ ] / or ASCII control characters 0-31 or 127
        /// Limit = 768 bytes
        /// </summary>
        public static void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new GeoFireException("Key cannot be the empty string");
            if ((11 + key.Length) > 755) throw new GeoFireException("Key is too long to be stored in Firebase");
            if (key.IndexOfAny(new[] { '.', '#', '$', ']', '[', '/' }) != -1) throw new GeoFireException(
                $"key '{key}' cannot contain any of the following characters: . # $ ] [ /");
        }

        /// <summary>
        /// Validates the location ensuring that the latitude and longitude are valid
        /// </summary>
        public static void ValidateLocation(double latitude, double longitude)
        {
            if (!ValidateLatitude(latitude))
                throw new GeoFireException("Latitude must be within the range [-90, 90]");
            if (!ValidateLongitude(longitude))
                throw new GeoFireException("Longitude must be within the range [-180, 180]");
        }

        /// <summary>
        /// Validates the latitude is not less than -90 and not greater than 90
        /// </summary>
        /// <param name="latitude">The latitude to test</param>
        /// <returns>True/False</returns>
        public static bool ValidateLatitude(double latitude)
        {
            return !(latitude < -90) && !(latitude > 90);
        }

        /// <summary>
        /// Validates the longitude is not less than -180 and not greater than 180
        /// </summary>
        /// <param name="longitude">The longitude to test</param>
        /// <returns>True/False</returns>
        public static bool ValidateLongitude(double longitude)
        {
            return !(longitude < -180) && !(longitude > 180);
        }
    }
}
