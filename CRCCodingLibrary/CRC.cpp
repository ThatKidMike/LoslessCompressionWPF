#include "CRC.h"

namespace tmpCRC {

	CRC::CRC(std::string msg, std::string chosenCRC)
		: msg(msg), chosenCRC(chosenCRC) {

		std::string data = msg;

		for (int i = 0; i < chosenCRC.length() - 1; i++) {
			data += '0';
		}

		vectorXOROperations.push_back(data);

		while (data.length() != chosenCRC.length()) {
			data = XorRightShift(data);
			vectorXOROperations.push_back(data);
		}

		data = XorRightShift(data);
		vectorXOROperations.push_back(data);
		finalCRC = data;

	}

	CRC::~CRC()
	{
	}

	std::string CRC::XorRightShift(std::string currentData)
	{
		std::string newData;
		bool wasShifted = false;

		for (int i = 0; i < chosenCRC.length(); i++) {

			if (currentData[0] == '1') {
				char xorResult = ((currentData[i]) - '0') ^ ((chosenCRC[i]) - '0');
				newData += xorResult + '0';
			}
			else if (currentData[0] == '0') {
				break;
			}

		}

		newData += currentData.substr(newData.length(), currentData.length() - newData.length());
		newData.erase(0, 1);

		return newData;

	}

	std::string CRC::GetFinalCRC()
	{
		return finalCRC;
	}

	std::vector<std::string>* CRC::GetListOfXorOperations()
	{
		return &vectorXOROperations;
	}

}