import 'package:intl/intl.dart';


//Helper function to get_time overloading method
class HelperFT{
  static String formatTime(){
    DateTime now = DateTime.now();
    return DateFormat.jm().format(now);
  }
}

// Helper function to create a DateTime object with offset
DateTime createDateTimeWithOffset(String datetime, String offset) {
  DateTime now = DateTime.parse(datetime);
  now = now.add(Duration(hours: int.parse(offset)));
  return now;
}

// Helper function to GetData of CurrentTime
class HelperGT{
  static String getCurrentTime(){
    return DateTime.now().toString();
  }
}

class LocationHelper {
  static String getLocationTime(String datetime, String offset) {
    // Parsing datetime to DateTime object
    DateTime locationTime = DateTime.parse(datetime);
    // Count the offset time to current hour
    int offsetHours = int.parse(offset);
    // change current time according to offset
    locationTime = locationTime.add(Duration(hours: offsetHours));
    // Return the time to current format
    return locationTime.toString();
  }
}