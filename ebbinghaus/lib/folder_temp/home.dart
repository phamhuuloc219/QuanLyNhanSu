// ignore_for_file: unused_import

import 'package:apploc/login_register/login.dart'; // Import your login screen
import 'package:apploc/login_register/register.dart'; // Import your register screen
import 'package:apploc/folder_temp/day.dart';
import 'package:flutter/material.dart';

class Home extends StatelessWidget {
  const Home({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Ebbinghaus"),
      ),
      body: Center(
          child: Column(children: [
        buttonBuider(context, title: "Day", destination: const Vocabulary()),
      ])),
    );
  }

  Widget buttonBuider(BuildContext context,
      {required String title, required Widget destination}) {
    return Padding(
      padding: const EdgeInsets.all(5.0),
      child: SizedBox(
        width: 120.0,
        child: ElevatedButton(
          onPressed: () => Navigator.push(
              context,
              MaterialPageRoute(
                builder: (context) => destination,
              )),
          child: Text(title),
        ),
      ),
    );
  }
}
