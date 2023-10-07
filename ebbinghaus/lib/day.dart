// ignore_for_file: library_private_types_in_public_api

import 'package:flutter/material.dart';

void main() {
  runApp(const Vocabulary());
}

class Vocabulary extends StatelessWidget {
  const Vocabulary({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Vocabulary App',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: const VocabularyScreen(),
    );
  }
}

class VocabularyScreen extends StatefulWidget {
  const VocabularyScreen({super.key});

  @override
  _VocabularyScreenState createState() => _VocabularyScreenState();
}

class _VocabularyScreenState extends State<VocabularyScreen> {
  List<Map<String, String>> vocabularyList = [];
  int editIndex = -1;

  TextEditingController wordController = TextEditingController();
  TextEditingController meaningController = TextEditingController();

  void addVocabulary() {
    String word = wordController.text;
    String meaning = meaningController.text;

    setState(() {
      if (editIndex != -1) {
        // Editing existing vocabulary
        vocabularyList[editIndex] = {'word': word, 'meaning': meaning};
        editIndex = -1;
      } else {
        // Adding new vocabulary
        vocabularyList.add({'word': word, 'meaning': meaning});
      }

      wordController.clear();
      meaningController.clear();
    });
  }

  void editVocabulary(int index) {
    setState(() {
      editIndex = index;
      wordController.text = vocabularyList[index]['word']!;
      meaningController.text = vocabularyList[index]['meaning']!;
    });
  }

  void deleteVocabulary(int index) {
    setState(() {
      vocabularyList.removeAt(index);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Ebbinghaus App'),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(16.0),
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    controller: wordController,
                    decoration: const InputDecoration(
                      labelText: 'Word',
                    ),
                  ),
                ),
                const SizedBox(width: 16.0),
                Expanded(
                  child: TextField(
                    controller: meaningController,
                    decoration: const InputDecoration(
                      labelText: 'Meaning',
                    ),
                  ),
                ),
              ],
            ),
          ),
          ElevatedButton(
            onPressed: addVocabulary,
            child:
                Text(editIndex != -1 ? 'Update Vocabulary' : 'Add Vocabulary'),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: vocabularyList.length,
              itemBuilder: (context, index) {
                return ListTile(
                  title: Text(vocabularyList[index]['word'] ?? ''),
                  subtitle: Text(vocabularyList[index]['meaning'] ?? ''),
                  trailing: Row(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      IconButton(
                        icon: const Icon(
                          Icons.edit,
                          color: Colors.black,
                        ),
                        onPressed: () => editVocabulary(index),
                      ),
                      IconButton(
                        icon: const Icon(
                          Icons.delete,
                          color: Colors.red,
                        ),
                        onPressed: () => deleteVocabulary(index),
                      ),
                    ],
                  ),
                );
              },
            ),
          ),
        ],
      ),
    );
  }
}
