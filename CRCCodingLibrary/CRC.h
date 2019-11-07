#pragma once
#include <string>
#include <vector>

namespace tmpCRC {

	class CRC {

	private:
		std::string msg;
		std::string chosenCRC;
		std::string finalCRC;
		std::vector<std::string> vectorXOROperations;
		std::string XorRightShift(std::string currentData);

	public:
		CRC(std::string msg, std::string chosenCRC);
		~CRC();

		std::string GetFinalCRC();
		std::vector<std::string>* GetListOfXorOperations();
	};

}