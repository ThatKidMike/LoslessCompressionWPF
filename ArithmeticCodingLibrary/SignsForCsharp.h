#pragma once
#include "Sign.h"
#include <list>
#include <vector>


namespace ArithmeticCodingTmp {

	class SignsForCsharp {

	private:
		std::list<Sign>* listOfSigns;
		std::vector<char> vecSigns;
		std::vector<double> vecProbability;
		std::vector<double> vecStartRange;
		std::vector<double> vecEndRange;
		std::vector<double> vecEncodedStart;
		std::vector<double> vecEncodedEnd;
		double finalEncode;


	public:
		SignsForCsharp(std::list<Sign>* listofSigns, double finalEncode);

		char GetSign(int positionNumber);
		double GetProbability(int positionNumber);
		double GetStartRange(int positionNumber);
		double GetEndRange(int positionNumber);
		double GetEncodedStart(int positionNumber);
		double GetEncodedEnd(int positionNumber);

		double GetFinalEncode();

		std::vector<char> GetVecSigns();
		std::vector<double> GetVecProbability();
		std::vector<double> GetVecStartRange();
		std::vector<double> GetVecEndRange();
		std::vector<double> GetVecEncodedStart();
		std::vector<double> GetVecEncodedEnd();


	};

}
