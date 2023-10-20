import 'package:flutter/material.dart';

class Vocabulary extends StatelessWidget {
  const Vocabulary({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Vocabulary Day',
      theme: ThemeData(
        primarySwatch: Colors.yellow,
      ),
      home: const VocabularyScreen(),
    );
  }
}

class VocabularyScreen extends StatefulWidget {
  const VocabularyScreen({Key? key}) : super(key: key);

  @override
  _VocabularyScreenState createState() => _VocabularyScreenState();
}

class _VocabularyScreenState extends State<VocabularyScreen> {
  List<Map<String, String>> vocabularyList = [];
  int editIndex = -1;

  TextEditingController wordController = TextEditingController();
  TextEditingController meaningController = TextEditingController();

  void addVocabulary() {
    String word = wordController.text.trim();
    String meaning = meaningController.text.trim();

    if (word.isNotEmpty && meaning.isNotEmpty) {
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
  }

  void editVocabulary(int index) {
    setState(() {
      editIndex = index;
      wordController.text = vocabularyList[index]['word']!;
      meaningController.text = vocabularyList[index]['meaning']!;
    });
    showModalBottomSheet(
      context: context,
      isScrollControlled: true,
      builder: (BuildContext context) {
        return Padding(
          padding: MediaQuery.of(context).viewInsets,
          child: Padding(
            padding: const EdgeInsets.all(16.0),
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                TextField(
                  controller: wordController,
                  decoration: const InputDecoration(
                    labelText: 'Word',
                  ),
                ),
                const SizedBox(height: 16.0),
                TextField(
                  controller: meaningController,
                  decoration: const InputDecoration(
                    labelText: 'Meaning',
                  ),
                ),
                const SizedBox(height: 16.0),
                ElevatedButton(
                  onPressed: () {
                    addVocabulary();
                    Navigator.pop(context);
                  },
                  child: const Text('Update'),
                ),
              ],
            ),
          ),
        );
      },
    );
  }

  void deleteVocabulary(int index) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text('Delete Vocabulary'),
          content: const Text('Do you want to delete this vocabulary?'),
          actions: [
            TextButton(
              onPressed: () {
                setState(() {
                  vocabularyList.removeAt(index);
                });
                Navigator.of(context).pop();
              },
              child: const Text('Yes'),
            ),
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: const Text('No'),
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return WillPopScope(
      onWillPop: () async {
        Navigator.pop(context);
        return true;
      },
      child: Scaffold(
        appBar: AppBar(
          title: const Text('Vocabulary Day'),
          leading: IconButton(
            icon: const Icon(Icons.arrow_back),
            onPressed: () {
              Navigator.pop(context);
            },
          ),
        ),
        body: Column(
          children: [
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
        floatingActionButton: FloatingActionButton(
          onPressed: () {
            showModalBottomSheet(
              context: context,
              isScrollControlled: true,
              builder: (BuildContext context) {
                return Padding(
                  padding: MediaQuery.of(context).viewInsets,
                  child: Padding(
                    padding: const EdgeInsets.all(16.0),
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        TextField(
                          controller: wordController,
                          decoration: const InputDecoration(
                            labelText: 'Word',
                          ),
                        ),
                        const SizedBox(height: 16.0),
                        TextField(
                          controller: meaningController,
                          decoration: const InputDecoration(
                            labelText: 'Meaning',
                          ),
                        ),
                        const SizedBox(height: 16.0),
                        ElevatedButton(
                          onPressed: () {
                            addVocabulary();
                            Navigator.pop(context);
                          },
                          child: const Text('Add'),
                        ),
                      ],
                    ),
                  ),
                );
              },
            );
          },
          child: const Icon(Icons.add),
        ),
      ),
    );
  }
}

void main() {
  runApp(const MaterialApp(
    home: Vocabulary(),
  ));
}
