﻿using Bifrost.Fakes.Sagas;
using Bifrost.Sagas;
using Machine.Specifications;

namespace Bifrost.Specs.Sagas.for_ChapterTransitionHelper
{
    public class when_asking_generically_and_it_can_not_transition
    {
        static bool can_transition;

        Because of = () => can_transition = ChapterTransitionHelper.CanTransition<NonTransitionalChapter, TransitionalChapter>();

        It should_not_be_able_to_transition = () => can_transition.ShouldBeFalse();
    }
}
