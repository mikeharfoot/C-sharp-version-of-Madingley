using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Madingley
{
    /// <summary>
    /// Class to hold properties of a single cohort
    /// </summary>
    public class Cohort
    {
        
        /// <summary>
        /// Time step when the cohort was generated
        /// </summary>
        private uint _BirthTimeStep;
        /// <summary>
        /// Get time step when the cohort was generated
        /// </summary>
        public uint BirthTimeStep { get { return _BirthTimeStep; } }

        /// <summary>
        /// The time step at which this cohort reached maturity
        /// </summary>
        private uint _MaturityTimeStep;
        /// <summary>
        /// Get and set the time step at which this cohort reached maturity
        /// </summary>
        public uint MaturityTimeStep { get { return _MaturityTimeStep; }    set { _MaturityTimeStep = value; }}

        /// <summary>
        /// A list of all cohort IDs ever associated with individuals in this current cohort
        /// </summary>
        private List<UInt32> _CohortID= new List<UInt32>();
        /// <summary>
        /// Get the list of all cohort IDs ever associated with individuals in this current cohort
        /// </summary>
        public List<UInt32> CohortID {  get { return _CohortID; } }
      

        /// <summary>
        /// The mean juvenile mass of individuals in this cohort
        /// </summary>
        private double _JuvenileMass;
        /// <summary>
        /// Get the mean juvenile mass of individuals in this cohort
        /// </summary>
        public double JuvenileMass { get { return _JuvenileMass; } }

        /// <summary>
        /// The mean mature adult mass of individuals in this cohort
        /// </summary>
        private double _AdultMass;
        /// <summary>
        /// Get the mean mature adult mass of individuals in this cohort
        /// </summary>
        public double AdultMass { get { return _AdultMass; } }

        /// <summary>
        /// The mean body mass of an individual in this cohort
        /// </summary>
        private double _IndividualBodyMass;
        /// <summary>
        /// Get or set the mean body mass of an individual in this cohort
        /// </summary>
        public double IndividualBodyMass
        {
            get { return _IndividualBodyMass; }
            set { _IndividualBodyMass = value; }
        }

        /// <summary>
        /// Individual biomass assigned to reproductive potential
        /// </summary>
        private double _IndividualReproductivePotentialMass;
        /// <summary>
        /// Get or set the individual biomass assigned to reproductive potential
        /// </summary>
        public double IndividualReproductivePotentialMass
        {
            get { return _IndividualReproductivePotentialMass; }
            set { _IndividualReproductivePotentialMass = value; }
        }

        /// <summary>
        /// The maximum mean body mass ever achieved by individuals in this cohort
        /// </summary>
        private double _MaximumAchievedBodyMass;
        /// <summary>
        /// Get or set the maximum mean body mass ever achieved by individuals in this cohort
        /// </summary>
        public double MaximumAchievedBodyMass
        {
            get { return _MaximumAchievedBodyMass; }
            set { _MaximumAchievedBodyMass = value; }
        }
        
        /// <summary>
        /// The number of individuals in the cohort
        /// </summary>
        private double _CohortAbundance;
        /// <summary>
        /// Get or set the number of individuals in the cohort
        /// </summary>
        public double CohortAbundance
        {
            get { return _CohortAbundance; }
            set { _CohortAbundance = value; }
        }

        /// <summary>
        /// The index of the functional group that the cohort belongs to
        /// </summary>
        private byte _FunctionalGroupIndex;
        /// <summary>
        /// Get the index of the functional group that the cohort belongs to
        /// </summary>
        public byte FunctionalGroupIndex { get { return _FunctionalGroupIndex; } }

        /// <summary>
        /// Whether this cohort has ever been merged with another cohort
        /// </summary>
        private Boolean _Merged;
        /// <summary>
        /// Get or set whether this cohort has ever been merged with another cohort
        /// </summary>
        public Boolean Merged
        {
            get { return _Merged; }
            set { _Merged = value; }
        }

        /// <summary>
        /// The proportion of the timestep for which this cohort is active
        /// </summary>
        private double _ProportionTimeActive;
        /// <summary>
        /// Get and set the proportion of time for which this cohort is active
        /// </summary>
        public double ProportionTimeActive
        {
            get { return _ProportionTimeActive; }
            set { _ProportionTimeActive = value; }
        }

        /// <summary>
        /// The trophic index for this cohort at this time
        /// </summary>
        private double _TrophicIndex;
        /// <summary>
        /// Get and set the trophic index
        /// </summary>
        public double TrophicIndex
        {
            get { return _TrophicIndex; }
            set { _TrophicIndex = value; }
        }
        

        /// <summary>
        /// The optimal prey body size for individuals in this cohort
        /// </summary>
        private double _LogOptimalPreyBodySizeRatio;
        /// <summary>
        /// Get and set the optimal prey body size for individuals in this cohort
        /// </summary>
        public double LogOptimalPreyBodySizeRatio 
        {
            get { return _LogOptimalPreyBodySizeRatio ; }
            set { _LogOptimalPreyBodySizeRatio = value; }
        }

        private double _SaltConcentration;

        public double SaltConcentration
        {
            get { return _SaltConcentration; }
            set { _SaltConcentration = value; }
        }


        private double[] _GutMasses;
        public double[] GutMasses
        {
            get { return _GutMasses; }
            set { _GutMasses = value; }
        }

        private double _SaltDefecit;

        public double SaltDefecit
        {
            get { return _SaltDefecit; }
            set { _SaltDefecit = value; }
        }
        

        private double _GutSaltConcentration;
        public double GutSaltConcentration
        {
            get { return _GutSaltConcentration; }
            set { _GutSaltConcentration = value; }
        }
        
        

        /// <summary>
        /// Constructor for the Cohort class: assigns cohort starting properties
        /// </summary>
        /// <param name="functionalGroupIndex">The functional group index of the cohort being generated</param>
        /// <param name="juvenileBodyMass">The mean juvenile body mass of individuals in the cohort</param>
        /// <param name="adultBodyMass">The mean mature adult body mass of individuals in the cohort</param>
        /// <param name="initialBodyMass">The intial mean body mass of individuals in this cohort</param>
        /// <param name="initialAbundance">The intial number of individuals in this cohort</param>
        /// <param name="optimalPreyBodySizeRatio">The optimal prey body mass (as a percentage of this cohorts mass) for individuals in this cohort</param>
        /// <param name="birthTimeStep">The birth time step for this cohort</param>
        /// <param name="proportionTimeActive">The proportion of time that the cohort will be active for</param>
        /// <param name="nextCohortID">The unique ID to assign to the next cohort created</param>
        /// <param name="trophicIndex">The trophic level index of the cohort</param>
        /// <param name="tracking">Whether the process tracker is enabled</param>
        public Cohort(byte functionalGroupIndex, double juvenileBodyMass, double adultBodyMass, double initialBodyMass, 
            double initialAbundance, double optimalPreyBodySizeRatio, ushort birthTimeStep, double proportionTimeActive, ref Int64 nextCohortID,
            double trophicIndex, Boolean tracking, double saltConcentration)
        {
            _FunctionalGroupIndex = functionalGroupIndex;
            _JuvenileMass = juvenileBodyMass;
            _AdultMass = adultBodyMass;
            _IndividualBodyMass = initialBodyMass;
            _CohortAbundance = initialAbundance;
            _BirthTimeStep = birthTimeStep;
            _MaturityTimeStep = uint.MaxValue;
            _LogOptimalPreyBodySizeRatio = Math.Log(optimalPreyBodySizeRatio);
            _MaximumAchievedBodyMass = juvenileBodyMass;
            _Merged = false;
            _TrophicIndex = trophicIndex;
            _ProportionTimeActive = proportionTimeActive;
            if(tracking)_CohortID.Add(Convert.ToUInt32(nextCohortID));
            nextCohortID++;
            _SaltConcentration = saltConcentration;
            _GutMasses = new double[]{0,0,0};
            _GutSaltConcentration = 0;
        }

        public Cohort(byte functionalGroupIndex, double juvenileBodyMass, double adultBodyMass, double initialBodyMass,
            double initialAbundance, double logOptimalPreyBodySizeRatio, double maxAchievedBodyMass, ushort birthTimeStep, ushort maturityTimestep, double proportionTimeActive, ref Int64 nextCohortID,
            double trophicIndex, Boolean tracking, double saltConcentration)
        {
            _FunctionalGroupIndex = functionalGroupIndex;
            _JuvenileMass = juvenileBodyMass;
            _AdultMass = adultBodyMass;
            _IndividualBodyMass = initialBodyMass;
            _CohortAbundance = initialAbundance;
            _BirthTimeStep = birthTimeStep;
            _MaturityTimeStep = maturityTimestep;
            _LogOptimalPreyBodySizeRatio = logOptimalPreyBodySizeRatio;
            _MaximumAchievedBodyMass = maxAchievedBodyMass;
            _Merged = false;
            _TrophicIndex = trophicIndex;
            _ProportionTimeActive = proportionTimeActive;
            if (tracking) _CohortID.Add(Convert.ToUInt32(nextCohortID));
            nextCohortID++;
            _SaltConcentration = saltConcentration;
            _GutMasses = new double[] { 0, 0, 0 };
            _GutSaltConcentration = 0;
        }




        public Cohort(Cohort c)
        {
            _FunctionalGroupIndex = c._FunctionalGroupIndex;
            _JuvenileMass = c._JuvenileMass;
            _AdultMass = c._AdultMass;
            _IndividualBodyMass = c._IndividualBodyMass;
            _CohortAbundance = c._CohortAbundance;
            _BirthTimeStep = c._BirthTimeStep;
            _MaturityTimeStep = c._MaturityTimeStep;
            _LogOptimalPreyBodySizeRatio = c._LogOptimalPreyBodySizeRatio;
            _MaximumAchievedBodyMass = c._MaximumAchievedBodyMass;
            _Merged = c._Merged;
            _TrophicIndex = c._TrophicIndex;
            _ProportionTimeActive = c._ProportionTimeActive;
            _CohortID = c.CohortID;
            _SaltConcentration = c._SaltConcentration;
            _GutMasses = new double[] { 0, 0,0};
            _GutSaltConcentration = 0;
        }


        public void UpdateGutContents(double bIngested, double saltConcentration, double bAssimilated)
        {
            double SaltRequired = (bAssimilated * _SaltConcentration);
            double IngestedSaltAvailable = (bIngested * saltConcentration);
            double TotalGutMass = _GutMasses.Sum();
            double RSalts = SaltRequired/IngestedSaltAvailable;
            //If there is not enough salt in the ingested matter try taking it from the gut contents
            if(RSalts > 1.0)
            {
                double GutSaltRequired = SaltRequired - IngestedSaltAvailable;
                double GutSaltAvailable = TotalGutMass * _GutSaltConcentration;
                //Unmet salt needs are attempted to be met by consumption from soil salt
                _SaltDefecit += Math.Max(0.0,SaltRequired-GutSaltAvailable);
                _GutSaltConcentration = 1 - (Math.Min(1.0,_GutMasses.Sum() * _GutSaltConcentration/SaltRequired));
            }
            else
            {
                //If this cohort has a salt defecit try taking it from the ingested material
                double ExcessSaltUsed = Math.Min(_SaltDefecit,IngestedSaltAvailable - SaltRequired);
                _SaltDefecit -= ExcessSaltUsed;

                _GutSaltConcentration = ((TotalGutMass * _GutSaltConcentration) + (1 - ((SaltRequired + ExcessSaltUsed)/ IngestedSaltAvailable)) * bIngested) / (TotalGutMass + bIngested - bAssimilated);
            }

            _GutMasses[0] += bIngested-bAssimilated;
            

        }

        public double[] CalculateGutLoss()
        {

            double SaltToSoil;
            double MassToSoil;

            //Mass loss rate is equal to the mass intake over the current and previous two timesteps
            MassToSoil = (_GutMasses.Sum()) / (_GutMasses.Length);
            SaltToSoil = MassToSoil * _GutSaltConcentration;



            return new double []{ SaltToSoil, MassToSoil };
        }

    }
}
