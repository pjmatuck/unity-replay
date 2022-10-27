using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ReplaySystem : MonoBehaviour
{
    [SerializeField] GameObject player;

    PlayerStatsModel playerStats;

    public void SaveState()
    {
        var playerTransform = player.transform;
        var playerAnim = player.GetComponent<Animator>();

        playerStats = new PlayerStatsModel(
            playerTransform.position,
            playerTransform.rotation,
            playerAnim.GetCurrentAnimatorStateInfo(0).shortNameHash,
            playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime,
            GetAnimParameters(playerAnim)
        );
    }

    public void RestoreState()
    {
        var playerTransform = player.transform;
        var playerAnim = player.GetComponent<Animator>();

        playerTransform.position = playerStats.Position;
        playerTransform.rotation = playerStats.Rotation;
        playerAnim.Play(playerStats.AnimHashName, 0, playerStats.AnimNormalTime);
        SetAnimParameters(playerAnim, playerStats.AnimParameters);
    }

    float[] GetAnimParameters(Animator anim)
    {
        List<float> parametersValues = new List<float>();
        for (int i = 0; i < anim.parameters.Length; i++)
        {
            parametersValues.Add(GetAnimParameterValue(anim, i));
        }

        return parametersValues.ToArray();
    }

    void SetAnimParameters(Animator anim, float[] values)
    {
        for (int i = 0; i < anim.parameters.Length; i++)
        {
            switch (anim.parameters[i].type)
            {
                case AnimatorControllerParameterType.Bool:
                    anim.SetBool(anim.parameters[i].nameHash, Convert.ToBoolean(values[i]));
                    break;
                case AnimatorControllerParameterType.Int:
                    anim.SetInteger(anim.parameters[i].nameHash, Convert.ToInt32(values[i]));
                    break;
                case AnimatorControllerParameterType.Float:
                    anim.SetFloat(anim.parameters[i].nameHash, values[i]);
                    break;
            }
        }
    }

    float GetAnimParameterValue(Animator anim, int index)
    {
        float value = 0;
        var parameter = anim.GetParameter(index);
        {
            switch (parameter.type)
            {
                case AnimatorControllerParameterType.Bool:
                    value = Convert.ToSingle(anim.GetBool(parameter.name));
                    break;
                case AnimatorControllerParameterType.Float:
                    value = Convert.ToSingle(anim.GetFloat(parameter.name));
                    break;
                case AnimatorControllerParameterType.Int:
                    value = Convert.ToSingle(anim.GetInteger(parameter.name));
                    break;
            }
        }
        return value;
    }
}