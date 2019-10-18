#pragma once

namespace ArithmeticCodingTmp {

	class Sign {

	private:
		char sign;
		int probability;
		double startRange = 0;
		double endRange = 1;
		double encodedStart;
		double encodedEnd;
	public:
		Sign(char sign, int probability);
		~Sign(void);

		char GetSign();
		int GetProbability();

		double GetStartRange();
		double GetEndRange();
		void SetStartRange(double startRange);
		void SetEndRange(double endRange);

		double GetEncodedStart();
		double GetEncodedEnd();
		void SetEncodedStart(double encodedStart);
		void SetEncodedEnd(double encodedEnd);
		
		void SetProbability(int probability);

	};

}
