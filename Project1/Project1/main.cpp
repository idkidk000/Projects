#include <iostream>
#include <string>
using namespace std;

int main(){
	cout << "Test message\n";
	string myText;
	getline(cin, myText);
	cout << myText << endl;
	system("pause");
	return 0;
}