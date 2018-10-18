﻿using UnityEngine;
//using System.Collections;

// =================================================================================================================================================================
/// <summary>
/// Cette classe contient les paramètres généraux et globaux utilisés dans le logiciel.
/// N'hérite pas de monobehavior et est un singleton.
/// </summary>

public class MainParameters
{
	#region Interpolation
	public enum InterpolationType { Quintic, CubicSpline };

	/// <summary> Description de la structure contenant les informations sur le type d'interpolation utilisé (quintic ou spline cubique). </summary>
	public struct StrucInterpolation
	{
		public InterpolationType type;
		public int numIntervals;
	}

	/// <summary> Structure contenant les informations sur le type d'interpolation utilisé par défaut. </summary>
	public StrucInterpolation interpolationDefault;
	#endregion

	#region Nodes
	/// <summary> Description de la structure contenant les données des noeuds. </summary>
	public struct StrucNodes
	{
		public int ddl;
		public string name;
		public float[] T;
		public float[] Q;
		public StrucInterpolation interpolation;
		/// <summary> Pointeur, dans la structure Nodes, de l'articulation (ddl) du côté opposé (gauche <-> droit), si aucun côté = -1. </summary>
		public int ddlOppositeSide;
	}
	#endregion

	#region TakeOffParameters
	/// <summary> Description de la structure contenant les paramètres de décollage. </summary>
	public struct StrucTakeOffParam
	{
		public float verticalSpeed;
		public float anteroposteriorSpeed;
		public float somersaultSpeed;
		public float twistSpeed;
		public float tilt;
		public float rotation;
	}

    /// <summary> Structure contenant les valeurs de défaut pour les paramètres de décollage. </summary>
    public StrucTakeOffParam takeOffParamDefault;
    #endregion

	public enum DataType { Simulation};
	public enum LagrangianModelNames { Simple, Sasha23ddl};

    #region Joints
    /// <summary> Description de la structure contenant les données des angles des articulations (DDL). </summary>
    public struct StrucJoints
	{
		/// <summary> Nom du fichier de données utilisé. </summary>
		public string fileName;
		/// <summary> Structure contenant les données des noeuds. </summary>
		public StrucNodes[] nodes;
		/// <summary> Liste des temps utilisés par les données interpolées. [m] = frames. </summary>
		public float[] t0;
		/// <summary> Liste des angles interpolés pour chacune des articulations. [m,n]: m = Frames, n = DDL. </summary>
		public float[,] q0;
		/// <summary> Nombre de frames contenu dans les données (q0). </summary>
		public int numberFrames;
		/// <summary> Durée de la figure. </summary>
		public float duration;
		/// <summary> Structure contenant les données relatifs aux paramètres initiaux d'envol. </summary>
		public StrucTakeOffParam takeOffParam;
		/// <summary> Condition utilisée pour exécuter la figure. </summary>
		public int condition;
		/// <summary> Type de données utilisée. </summary>
		public DataType dataType;
		/// <summary> Nom du modèle Lagrangien utilisée. </summary>
		public LagrangianModelNames lagrangianModelName;
		/// <summary> Structure du modèle Lagrangien utilisée. </summary>
		public LagrangianModelManager.StrucLagrangianModel lagrangianModel;
	}

	/// <summary> Structure contenant les données des angles des articulations (DDL). </summary>
	public StrucJoints joints;

    /// <summary> Valeur de défaut pour la durée de la figure. </summary>
    public float durationDefault;

    /// <summary> Valeur de défaut pour la condition utilisée pour exécuter la figure. </summary>
    public int conditionDefault;
    #endregion

    #region SplinesParameters
    ///// <summary> Description de la structure contenant les coefficents splines interpolés des données réelles des angles des articulations (DDL). </summary>
    //// Interpolation de type spline cubique
    //public struct StrucCoefSplines
    //{
    //	public float[,] pp;					// [m,n] --> m = nombre de frames, n = nombre de coefficents
    //	public float[,] ppdot;              // [m,n] --> m = nombre de frames, n = nombre de coefficents
    //	public float[,] ppddot;             // [m,n] --> m = nombre de frames, n = nombre de coefficents
    //}

    ///// <summary> Description de la structure contenant les données relatifs aux splines interpolés des données réelles des angles des articulations (DDL). </summary>
    //public struct StrucSplines
    //{
    //	public float[] T;                   // [n] --> n = nombre de frames
    //	public StrucCoefSplines[] coefs;    // [n] --> n = nombre de DDL
    //}

    ///// <summary> Structure contenant les coefficents splines interpolés des données réelles des angles des articulations (DDL). </summary>
    //public StrucSplines splines;
    #endregion

	#region singleton 
	// modèle singleton tiré du site : https://msdn.microsoft.com/en-us/library/ff650316.aspx
	private static MainParameters instance;

	// =================================================================================================================================================================

	private MainParameters()
	{
		// Initialisation des paramètres à leurs valeurs de défaut.

		interpolationDefault.type = InterpolationType.Quintic;
		interpolationDefault.numIntervals = 0;
        takeOffParamDefault.verticalSpeed = 0;
        takeOffParamDefault.anteroposteriorSpeed = 0;
        takeOffParamDefault.somersaultSpeed = 0;
        takeOffParamDefault.twistSpeed = 0;
        takeOffParamDefault.tilt = 0;
        takeOffParamDefault.rotation = 0;
		durationDefault = 0;
		conditionDefault = 0;

		// Initialisation des paramètres reliés aux données des angles des articulations.

		joints.fileName = "";
		joints.nodes = null;
		joints.t0 = null;
		joints.q0 = null;
		joints.numberFrames = 0;
		joints.duration = durationDefault;
		joints.takeOffParam = takeOffParamDefault;
		joints.condition = conditionDefault;
		joints.dataType = DataType.Simulation;
		joints.lagrangianModelName = LagrangianModelNames.Simple;
		joints.lagrangianModel = new LagrangianModelManager.StrucLagrangianModel();

		// Initialisation des paramètres reliés aux coefficents splines interpolés des données réelles des angles des articulations.

		//splines = new StrucSplines();
		//splines.coefs = null;
	}

	// =================================================================================================================================================================

	public static MainParameters Instance
	{
		get
		{
			if (instance == null) instance = new MainParameters();
			return instance;
		}
	}
	#endregion
}
