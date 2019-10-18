#pragma once

#include "ProcessInput.h"
#include "SignsForCsharp.h"

namespace ArithmeticCodingTmp {

	class ProcessCompression {

	private:
		double high = 1.0;
		double low = 0.0;
		double range = 0.0;
		std::list<Sign>* listOfSigns;
		SignsForCsharp* signsForCsharp;

	public:
		ProcessCompression(std::list<Sign>* listOfSigns);
		~ProcessCompression(void);
		SignsForCsharp* GetSignsForCsharp();
		double GetHigh();
		double GetLow();
		void SetHigh(double high);
		void SetLow(double low);







	};



}