using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerStatsModel
    {
        Vector3 _position;
        Quaternion _rotation;
        int _animHashName;
        float _animNormalTime;
        float[] _animParameters;

        public PlayerStatsModel(Vector3 position, Quaternion rotation, int animHashName, float animNormalTime, float[] animParameters)
        {
            _position = position;
            _rotation = rotation;
            _animHashName = animHashName;
            _animNormalTime = animNormalTime;
            _animParameters = animParameters;
        }

        public Vector3 Position => _position;

        public Quaternion Rotation => _rotation;

        public int AnimHashName => _animHashName;

        public float AnimNormalTime => _animNormalTime;

        public float[] AnimParameters => _animParameters;
    }
}