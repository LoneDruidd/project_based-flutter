import 'package:http/http.dart';
import 'dart:convert';
import 'package:world_time/services/helper_function.dart';

class WorldTime {
  String location; // location name for the UI
  String time = ''; // the time in that location
  String flag; // url to on asset flag icon
  String url; // location url for API endpoint
  bool isDaytime; // true or false if dayTime or not

  WorldTime({required this.location, required this.flag, required this.url})
      : isDaytime = false;

  Future<void> getTime({bool withFormatting = true}) async {
    try {
      // make request
      final Response response = await get(Uri.parse('https://worldtimeapi.org/api/timezone/$url'));
      Map data = jsonDecode(response.body);

      //Encapsulate data retrieval and processing
      _setData(data);

      // set the time property
      if (withFormatting) {
        time = HelperFT.formatTime();
      } else {
        time = HelperGT.getCurrentTime();
      }
    } catch (e) {
      print('caught error: $e');
      time = '..';
    }
  }

  void _setData(Map data) {
    String datetime = data['datetime'];
    String offset = data['utc_offset'].substring(0, 3);

    // create datetime object
    DateTime now = createDateTimeWithOffset(datetime, offset);

    //set the isDaytime property
    isDaytime = now.hour > 6 && now.hour < 20;
  }
}
