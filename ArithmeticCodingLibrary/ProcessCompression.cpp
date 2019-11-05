#include "ProcessCompression.h"
#include <iostream>
#include <iomanip>

namespace ArithmeticCodingTmp {

	ProcessCompression::ProcessCompression(std::list<Sign>* listOfSigns)
		: listOfSigns(listOfSigns) {

		double cumulativeProb = 0.0;
		auto it = listOfSigns->begin();
		double previousProb = 0.0;

		it->SetStartRange(0.0);
		it->SetEndRange(it->GetProbability());
		previousProb = it->GetEndRange();
		cumulativeProb += (it->GetProbability());
		it++;

		for (it; it != listOfSigns->end(); it++) {

			it->SetStartRange(previousProb);
			cumulativeProb += (it->GetProbability());
			it->SetEndRange(cumulativeProb);
			previousProb = it->GetEndRange();

		}

		double range = 0.0;
		high = 1.0;
		low = 0.0;

		for (it = listOfSigns->begin(); it != listOfSigns->end(); it++) {

			range = high - low;
			high = low + range * it->GetEndRange();
			low = low + range * it->GetStartRange();

			it->SetEncodedStart(low);
			it->SetEncodedEnd(high);


		}

		double finalEncoded = low + (high - low) / 2;


		for (auto it = listOfSigns->begin(); it != listOfSigns->end(); it++) {

			std::cout << "Value: " << it->GetSign() << " Range[" << it->GetStartRange() << ";" << it->GetEndRange() << "] \n";

		}

		std::cout << "----------------------------------------------- \n";

		for (auto it = listOfSigns->begin(); it != listOfSigns->end(); it++) {

			std::cout << std::setprecision(15) << "Value: " << it->GetSign() << " Range[" << it->GetEncodedStart() << ";" << it->GetEncodedEnd() << "] \n";

		}

		std::cout << std::setprecision(15) << "Encoded input: " << finalEncoded;

		signsForCsharp = new SignsForCsharp(listOfSigns, finalEncoded);

	}

	ProcessCompression::~ProcessCompression(void) {

	}

	SignsForCsharp* ProcessCompression::GetSignsForCsharp() {
		return signsForCsharp;
	}



}