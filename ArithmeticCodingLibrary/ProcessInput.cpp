#include "ProcessInput.h"
#include <iostream>
#include <cstdlib>
#include <math.h> 
#include <ctime>
#include "ProcessCompression.h"

namespace ArithmeticCodingTmp {


	ProcessInput::ProcessInput(std::string inputStream, double listOfProbabilities[])
		: inputStream(inputStream) {

		//int probLeft = 100;
		//int calculatedProb = 0;
		//double generatedRnd[100];
		//double sum = 0;
		//int newSum = 0;

		//srand(time(NULL));

		//for (int i = 0; i < inputStream.size() - 1; i++) {
		//		
		//	generatedRnd[i] = rand() % 100 + 1;

		//}

		//for (int i = 0; i < inputStream.size() - 1; i++) {

		//	sum += generatedRnd[i];

		//}

		//for (int i = 0; i < inputStream.size() - 1; i++) {

		//	generatedRnd[i] *= 100 / sum;
		//}

		//for (int i = 0; i < inputStream.size() - 1; i++) {
		//	if (generatedRnd[i] < 1) {
		//		listOfSigns.push_back(Sign(inputStream[i], std::ceil(generatedRnd[i])));
		//	}
		//	else {
		//		listOfSigns.push_back(Sign(inputStream[i], generatedRnd[i]));
		//	}
		//}

		//for (auto it = listOfSigns.begin(); it != listOfSigns.end(); it++) {

		//	//it->SetProbability(it->GetProbability() - 2);
		//	newSum += it->GetProbability();

		//}


		//listOfSigns.push_back(Sign(inputStream[inputStream.size() - 1], 100-newSum));

		for (int i = 0; i < inputStream.size(); i++) {
			listOfSigns.push_back(Sign(inputStream[i], listOfProbabilities[i]));
		}

		ProcessCompression* pc = new ProcessCompression(&listOfSigns);

		vectorChar = pc->GetSignsForCsharp()->GetVecSigns();
		vectorProbability = pc->GetSignsForCsharp()->GetVecProbability();
		vectorStartRange = pc->GetSignsForCsharp()->GetVecStartRange();
		vectorEndRange = pc->GetSignsForCsharp()->GetVecEndRange();
		vectorEncodedStart = pc->GetSignsForCsharp()->GetVecEncodedStart();
		vectorEncodedEnd = pc->GetSignsForCsharp()->GetVecEncodedEnd();
		finalEncode = pc->GetSignsForCsharp()->GetFinalEncode();

		delete pc->GetSignsForCsharp();
		delete pc;

	}

	ProcessInput::~ProcessInput(void) {
	}

	double ProcessInput::GetFinalEncode() {
		return finalEncode;
	}

	char ProcessInput::GetVecSign(int positionNumber) {
		return vectorChar[positionNumber];
	}

	double ProcessInput::GetVecProbability(int positionNumber) {
		return vectorProbability[positionNumber];
	}

	double ProcessInput::GetVecStartRange(int positionNumber) {
		return vectorStartRange[positionNumber];
	}

	double ProcessInput::GetVecEndRange(int positionNumber) {
		return vectorEndRange[positionNumber];
	}

	double ProcessInput::GetVecEncodedStart(int positionNumber) {
		return vectorEncodedStart[positionNumber];
	}

	double ProcessInput::GetVecEncodedEnd(int positionNumber) {
		return vectorEncodedEnd[positionNumber];
	}

	std::string ProcessInput::GetInputStream() {
		return this->inputStream;
	}

	std::list<Sign> ProcessInput::GetListOfSigns() {
		return this->listOfSigns;
	}
}