#include "SignsForCsharp.h"
#include <iostream>

namespace ArithmeticCodingTmp {

	SignsForCsharp::SignsForCsharp(std::list<Sign>* listOfSigns, double finalEncode) {

		int n = 0;

		for (auto it = listOfSigns->begin(); it != listOfSigns->end(); it++) {

			vecSigns.push_back(it->GetSign());
			vecProbability.push_back(it->GetProbability());
			vecStartRange.push_back(it->GetStartRange());
			vecEndRange.push_back(it->GetEndRange());
			vecEncodedStart.push_back(it->GetEncodedStart());
			vecEncodedEnd.push_back(it->GetEncodedEnd());

			n++;

		}

		this->finalEncode = finalEncode;

	}

	double SignsForCsharp::GetFinalEncode() {
		return this->finalEncode;
	}

	char SignsForCsharp::GetSign(int positionNumber) {
		return vecSigns[positionNumber];
	}

	double SignsForCsharp::GetProbability(int positionNumber) {
		return vecProbability[positionNumber];
	}

	double SignsForCsharp::GetStartRange(int positionNumber) {
		return vecStartRange[positionNumber];
	}

	double SignsForCsharp::GetEndRange(int positionNumber) {
		return vecEndRange[positionNumber];
	}


	double SignsForCsharp::GetEncodedStart(int positionNumber) {
		return vecEncodedStart[positionNumber];
	}


	double SignsForCsharp::GetEncodedEnd(int positionNumber) {
		return vecEncodedEnd[positionNumber];
	}

	std::vector<char> SignsForCsharp::GetVecSigns() {
		return vecSigns;
	}

	std::vector<double> SignsForCsharp::GetVecProbability() {
		return vecProbability;
	}

	std::vector<double> SignsForCsharp::GetVecStartRange() {
		return vecStartRange;
	}

	std::vector<double> SignsForCsharp::GetVecEndRange() {
		return vecEndRange;
	}

	std::vector<double> SignsForCsharp::GetVecEncodedStart() {
		return vecEncodedStart;
	}

	std::vector<double> SignsForCsharp::GetVecEncodedEnd() {
		return vecEncodedEnd;
	}


}