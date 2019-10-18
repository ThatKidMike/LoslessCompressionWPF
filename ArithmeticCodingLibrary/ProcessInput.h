#pragma once

#include <string>
#include <list>
#include "Sign.h"
#include <stdexcept>
#include <vector>

namespace ArithmeticCodingTmp {

	class ProcessInput {

	private:
		std::string inputStream;
		std::list<Sign> listOfSigns;

		std::vector<char> vectorChar;
		std::vector<int> vectorProbability;
		std::vector<double> vectorStartRange;
		std::vector<double> vectorEndRange;
		std::vector<double> vectorEncodedStart;
		std::vector<double> vectorEncodedEnd;

		double finalEncode;

	public:
		ProcessInput(std::string inputStream);
		~ProcessInput(void);

		std::string GetInputStream();
		std::list<Sign> GetListOfSigns();

		double GetFinalEncode();
		char GetVecSign(int positionNumber);
		int GetVecProbability(int positionNumber);
		double GetVecStartRange(int positionNumber);
		double GetVecEndRange(int positionNumber);
		double GetVecEncodedStart(int positionNumber);
		double GetVecEncodedEnd(int positionNumber);

	};

}